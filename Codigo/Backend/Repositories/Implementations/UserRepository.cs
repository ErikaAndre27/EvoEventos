using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class UserRepository: IUserRepository
    {
        private readonly EvoeventosContext _context;
        public UserRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(Guid Id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<bool> CreateUser(User User)
        {
            try
            {
                _context.Users.Add(User);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteUser(Guid Id)
        {
            try
            {
                var User = await _context.Users.FindAsync(Id);
                if (User == null)
                {
                    return false;
                }
                _context.Users.Remove(User);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateUser(Guid Id, User UpdateUser)
        {
            try
            {
                var ExistingUser = await _context.Users.FindAsync(Id);
                if (ExistingUser == null)
                {
                    return false;
                }

                ExistingUser.Names = ExistingUser.Names;
                ExistingUser.UpdateAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.Users.Update(ExistingUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
