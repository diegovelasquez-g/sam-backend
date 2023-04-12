using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListSelectAllUsers();
        Task<User> UserById(int userId);
        Task<User> UserByEmail(string userEmail);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int userId);
        Task<bool> SignIn(string email, string password); 
    }
}
