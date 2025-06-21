using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Domain.Ports
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task CreateAsync(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
