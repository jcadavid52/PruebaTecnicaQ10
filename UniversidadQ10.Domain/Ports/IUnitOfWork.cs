namespace UniversidadQ10.Domain.Ports
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
