using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid Id);
        Task<bool> CreateUser(User User);
        Task<bool> UpdateUser(Guid Id, User UpdateUser);
        Task<bool> DeleteUser(Guid Id);
    }
}
