using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Domain.Ports
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllAsync();
        Task<Subject?> GetByIdAsync(int id);
        Task CreateAsync(Subject subject);
        void Update(Subject subject);
        void Delete(Subject subject);
    }
}
