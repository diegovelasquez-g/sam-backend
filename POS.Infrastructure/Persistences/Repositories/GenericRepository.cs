using Microsoft.EntityFrameworkCore;
using SAM.Infrastructure.Commons.Bases.Request;
using SAM.Infrastructure.Helpers;
using SAM.Infrastructure.Persistences.Contexts;
using SAM.Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;

namespace SAM.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SAMContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(SAMContext context, DbSet<T> entity)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public Task<IEnumerable<T>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
