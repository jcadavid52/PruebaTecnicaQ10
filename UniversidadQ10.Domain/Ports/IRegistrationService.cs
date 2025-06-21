using UniversidadQ10.Domain.Dtos;

namespace UniversidadQ10.Domain.Ports
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationDto>> GetAllRegistrationsAsync();
        Task CreateRegistrationAsync(RegistrationCreateDto registrationCreateDto);
    }
}
