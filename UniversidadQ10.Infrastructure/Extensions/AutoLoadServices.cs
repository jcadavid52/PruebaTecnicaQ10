using Microsoft.Extensions.DependencyInjection;
using UniversidadQ10.Domain.Common;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Infrastructure.Adapters;
using UniversidadQ10.Infrastructure.Ports;

namespace UniversidadQ10.Infrastructure.Extensions
{
    public static class AutoLoadServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            var _services = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly =>
                {
                    return (assembly.FullName is null) || assembly.FullName.Contains("Domain", StringComparison.InvariantCulture);
                })
                  .SelectMany(s => s.GetTypes())
                  .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));

            var _repositories = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly =>
                {
                    return assembly.FullName is null || assembly.FullName.Contains("Infrastructure", StringComparison.OrdinalIgnoreCase);
                })
                  .SelectMany(assembly => assembly.GetTypes())
                  .Where(type => type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(RepositoryAttribute)));

            foreach (var service in _services)
            {
                services.AddTransient(service);
            }

            foreach (var repository in _repositories)
            {
                Type typeInterface = repository.GetInterfaces().Single();
                services.AddTransient(typeInterface, repository);
            }

            return services;
        }
    }
}
