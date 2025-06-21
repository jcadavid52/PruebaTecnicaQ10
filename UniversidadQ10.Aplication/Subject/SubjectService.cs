using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Exceptions;
using UniversidadQ10.Domain.Ports;

namespace UniversidadQ10.Aplication.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubjectService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjectsList = await _subjectRepository.GetAllAsync();
            var subjectsListDto = subjectsList.Select(subject =>
                new SubjectDto(subject.Id,subject.Name,subject.Credit,subject.Code)
           );

            return subjectsListDto;
        }

        public async Task<SubjectDto> GetSubjectById(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);

            if (subject is null)
                throw new NotFoundException($"No se encontro entidad con id '{id}'");

            var SubjectDto = new SubjectDto(subject.Id,subject.Name,subject.Credit,subject.Code);
            return SubjectDto;
        }
        public async Task CreateSubjectAsync(SubjectCreateDto subjectCreateDto)
        {
            var subject = new Domain.Entities.Subject
            {
                Name = subjectCreateDto.Name,
                Credit = subjectCreateDto.Credit,
            };

            await _subjectRepository.CreateAsync(subject);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateSubjectAsync(int id, SubjectEditDto subjectEditDto)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);

            if (subject is null)
                throw new NotFoundException($"No se encontro entidad con id '{id}'");

            subject.Name = subjectEditDto.Name;
            subject.Credit = subjectEditDto.Credit;
            _subjectRepository.Update(subject);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);

            if (subject is null)
                throw new NotFoundException($"No se encontro entidad con id '{id}'");

            _subjectRepository.Delete(subject);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
