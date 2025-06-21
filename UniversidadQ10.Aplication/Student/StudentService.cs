using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Exceptions;
using UniversidadQ10.Domain.Ports;

namespace UniversidadQ10.Aplication.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IStudentRepository studentRepository,IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var studentsList = await _studentRepository.GetAllAsync();
            var studentsListDto = studentsList.Select(student =>
                new StudentDto(student.Id,student.FullName,student.Email,student.Document)
           );

            return studentsListDto;
        }

        public async Task<StudentDto> GetStudentById(int id)
        {
           var student = await _studentRepository.GetByIdAsync(id);

           if(student is null)
                throw new NotFoundException($"No se encontro entidad con id '{id}'");

           var studentDto = new StudentDto(student.Id, student.FullName, student.Email, student.Document);
           return studentDto;
        }
        public async Task CreateStudentAsync(StudentCreateDto studentDto)
        {
            var student = new UniversidadQ10.Domain.Entities.Student
            {
                Email = studentDto.Email,
                Document = studentDto.Document,
                FullName = studentDto.FullName,
            };

            await _studentRepository.CreateAsync(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student is null)
                throw new NotFoundException($"No se encontro entidad con id '{id}'");

            student.FullName = studentDto.FullName;
            student.Email = studentDto.Email;
            student.Document = studentDto.Document;
            _studentRepository.Update(student);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student is null)
                throw new NotFoundException($"No se encontro entidad con id '{id}'");

            _studentRepository.Delete(student);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
