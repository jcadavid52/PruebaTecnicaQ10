using UniversidadQ10.Domain.Dtos;

namespace UniversidadQ10.Domain.Ports
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentById(int id);
        Task CreateStudentAsync(StudentCreateDto studentDto);
        Task UpdateStudentAsync(int id, StudentDto studentDto);
        Task DeleteStudentAsync(int id);
    }
}
