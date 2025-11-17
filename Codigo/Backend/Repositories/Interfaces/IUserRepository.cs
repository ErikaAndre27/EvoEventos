using BackEvoEventos.Dtos;
using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid Id);
        Task<User> GetUserByEmail(string Email);
        Task<User> GetUserByDocumentNumber(string DocumentNumber);
        Task<bool> CreateUser(CreateUserDto UserDto);
        Task<bool> UpdateUser(Guid Id, User UpdateUser);
        Task<bool> DeleteUser(Guid Id);
    }
}
