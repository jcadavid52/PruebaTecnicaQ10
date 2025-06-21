using UniversidadQ10.Domain.Entities;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Infrastructure.Ports;

namespace UniversidadQ10.Infrastructure.Adapters
{
    [Repository]
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IGenericRepository<Registration> _genericRepository;
        private readonly ICountableRepository<Registration> _countableRepository;

        public RegistrationRepository(IGenericRepository<Registration> genericRepository, ICountableRepository<Registration> countableRepository)
        {
            _genericRepository = genericRepository;
            _countableRepository = countableRepository;
        }

        public async Task<IEnumerable<Registration>> GetAllAsync() => await _genericRepository.GetAllAsync(includeProperties: "Student,Subject");

        public async Task<int> CountAsync(int studentId, int quantityCredits) => await _countableRepository.CountAsync(includeProperties: "Student,Subject",filter:registration => registration.StudentId == studentId && registration.Subject.Credit >= quantityCredits);

        public async Task CreateAsync(Registration registration) => await _genericRepository.CreateAsync(registration);

        
    }
}
