using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Infrastructure.DataSource;

namespace UniversidadQ10.Infrastructure.Adapters
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
