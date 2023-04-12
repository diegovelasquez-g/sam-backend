using Microsoft.EntityFrameworkCore;
using SAM.Domain.Entities;
using SAM.Infrastructure.Persistences.Contexts;
using SAM.Infrastructure.Persistences.Interfaces;

namespace SAM.Infrastructure.Persistences.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SAMContext _context;

        public UserRepository(SAMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> ListSelectAllUsers()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();
            return users;
        }

        public async Task<User> UserByEmail(string userEmail)
        {
            var user = await _context.Users!.Where(x => x.Email.Equals(userEmail)).AsNoTracking().FirstOrDefaultAsync();
            return user!;
        }

        public async Task<User> UserById(int userId)
        {
            var user = await _context.Users!.Where(x => x.UserId.Equals(userId)).AsNoTracking().FirstOrDefaultAsync();
            return user!;
        }

        public async Task<bool> CreateUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            await _context.AddAsync(user);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> UpdateUser(User user)
        {
            user.ModifiedDate = DateTime.Now;
            _context.Update(user);
            _context.Entry(user).Property(x => x.CreatedDate).IsModified = false;
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserId.Equals(userId));
            user!.ModifiedDate = DateTime.Now;
            user!.IsActive = false;
            _context.Update(user);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public Task<bool> SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
