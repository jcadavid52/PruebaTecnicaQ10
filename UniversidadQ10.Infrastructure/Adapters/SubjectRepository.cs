using UniversidadQ10.Domain.Entities;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Infrastructure.Ports;

namespace UniversidadQ10.Infrastructure.Adapters
{
    [Repository]
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IGenericRepository<Subject> _genericRepository;

        public SubjectRepository(IGenericRepository<Subject> genericRepository)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException("Objeto null");
        }

        public async Task<IEnumerable<Subject>> GetAllAsync() => await _genericRepository.GetAllAsync();

        public async Task<Subject?> GetByIdAsync(int id) => await _genericRepository.GetByIdAsync(id);

        public async Task CreateAsync(Subject subject) => await _genericRepository.CreateAsync(subject);

        public void Update(Subject subject) => _genericRepository.Update(subject);

        public void Delete(Subject subject) => _genericRepository.Delete(subject);
    }
}
