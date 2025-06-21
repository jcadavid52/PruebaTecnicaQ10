using System.Linq.Expressions;
using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Infrastructure.Ports
{
    public interface ICountableRepository<T> : IGenericRepository<T> where T : DomainEntity
    {
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    }
}
