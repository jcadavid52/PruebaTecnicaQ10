using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniversidadQ10.Domain.Common;
using UniversidadQ10.Infrastructure.DataSource;
using UniversidadQ10.Infrastructure.Ports;

namespace UniversidadQ10.Infrastructure.Adapters
{
    public class GenericRepository<T> : IGenericRepository<T> where T : DomainEntity
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null, int? skip = null, int? take = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task CreateAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity) => _dbSet.Remove(entity);
        
    }
}
