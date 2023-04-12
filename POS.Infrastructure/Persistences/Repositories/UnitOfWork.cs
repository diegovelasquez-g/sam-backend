using Microsoft.Extensions.Configuration;
using SAM.Infrastructure.Persistences.Contexts;
using SAM.Infrastructure.Persistences.Interfaces;

namespace SAM.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SAMContext _context;
        public ICategoryRepository Category { get; private set; }
        public IUserRepository User { get; private set; }
        public UnitOfWork(SAMContext context, IConfiguration configuration)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            User = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
