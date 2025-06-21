using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using UniversidadQ10.Domain.Common;
using UniversidadQ10.Infrastructure.DataSource;
using UniversidadQ10.Infrastructure.Ports;

namespace UniversidadQ10.Infrastructure.Adapters
{
    public class CountableRepository<T> : GenericRepository<T>, ICountableRepository<T> where T : DomainEntity
    {
        private readonly DbSet<T> _dbSet;
        public CountableRepository(DataContext context) : base(context) 
        {
            _dbSet = context.Set<T>();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            if (filter != null)
                query = query.Where(filter);

            return await query.CountAsync();
        }
    }
}
