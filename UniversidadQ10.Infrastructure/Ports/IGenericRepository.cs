using System.Linq.Expressions;
using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Infrastructure.Ports
{
    public interface IGenericRepository<T> where T : DomainEntity
    {
        Task<IEnumerable<T>> GetAllAsync(
           Expression<Func<T, bool>>? filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           string? includeProperties = null,
           int? skip = null,
           int? take = null);

        Task<T?> GetByIdAsync(int id, string? includeProperties = null);

        Task CreateAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
