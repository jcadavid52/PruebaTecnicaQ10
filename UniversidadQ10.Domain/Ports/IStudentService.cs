using UniversidadQ10.Domain.Dtos;

namespace UniversidadQ10.Domain.Ports
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentById(int id);
        Task CreateStudentAsync(StudentCreateDto studentCreateDto);
        Task UpdateStudentAsync(int id, StudentEditDto studentEditDto);
        Task DeleteStudentAsync(int id);
    }
}
