using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Entities;
using UniversidadQ10.Domain.Exceptions;
using UniversidadQ10.Domain.Ports;

namespace UniversidadQ10.Aplication.Registration
{
    public class RegistrationService:IRegistrationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork, IRegistrationRepository registrationRepository)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
            _registrationRepository = registrationRepository;
        }

        public async Task<IEnumerable<RegistrationDto>> GetAllRegistrationsAsync()
        {
            var registrationList = await _registrationRepository.GetAllAsync();
            var registrationListDto = registrationList.Select(registration =>
                new RegistrationDto(registration.Student.FullName,registration.Subject.Name,registration.RegistrationDate,registration.Subject.Credit)
            );

            return registrationListDto;
        }

        public async Task CreateRegistrationAsync(RegistrationCreateDto registrationCreateDto)
        {
            var registration = new UniversidadQ10.Domain.Entities.Registration
            {
                StudentId = registrationCreateDto.StudentId,
                SubjectId = registrationCreateDto.SubjectId,
            };

            var subject = await _subjectRepository.GetByIdAsync(registration.SubjectId);

            if (subject is null)
                throw new NotFoundException($"No se encontro entidad con id '{registration.SubjectId}'");

            if (subject.Credit <= 3)
            {
                await _registrationRepository.CreateAsync(registration);
                await _unitOfWork.SaveChangesAsync();

                return;
            }

            var quantitySubjects = await _registrationRepository.CountAsync(registration.StudentId,3);

            registration.ValidateCreditsSubjectStudent(quantitySubjects);

            await _registrationRepository.CreateAsync(registration);
            await _unitOfWork.SaveChangesAsync();
        }

      
    }
}
