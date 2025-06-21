using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Domain.Ports
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<Registration>> GetAllAsync();
        Task<int> CountAsync(int studentId, int quantityCredits);
        Task CreateAsync(Registration registration);
        
    }
}
