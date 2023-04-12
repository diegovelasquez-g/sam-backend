namespace SAM.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaración de las interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
