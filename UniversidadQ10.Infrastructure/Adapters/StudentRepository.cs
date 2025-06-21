using UniversidadQ10.Domain.Entities;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Infrastructure.Ports;

namespace UniversidadQ10.Infrastructure.Adapters
{
    [Repository]
    public class StudentRepository : IStudentRepository
    {
        private readonly IGenericRepository<Student> _genericRepository;

        public StudentRepository(IGenericRepository<Student> genericRepository)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException("Objeto null");
        }

        public async Task<IEnumerable<Student>> GetAllAsync() => await _genericRepository.GetAllAsync();

        public async Task<Student?> GetByIdAsync(int id) => await _genericRepository.GetByIdAsync(id);

        public async Task CreateAsync(Student student) => await _genericRepository.CreateAsync(student);

        public void Update(Student student) => _genericRepository.Update(student);

        public void Delete(Student student) => _genericRepository.Delete(student);
        
    }
}
