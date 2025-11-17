using BackEvoEventos.Context;
using BackEvoEventos.Dtos;
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

        public async Task<User> GetUserByEmail(string Email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == Email);
        }

        public async Task<User> GetUserByDocumentNumber(string DocumentNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.DocumentNumber == DocumentNumber);
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }



        public async Task<bool> CreateUser(CreateUserDto UserDto)
        {
            try
            {

                var User = new User
                {
                    Names = UserDto.Names,
                    Surnames = UserDto.Surnames,
                    Email = UserDto.Email,
                    Phone = UserDto.Phone,
                    IdDocumentType = UserDto.IdDocumentType,
                    DocumentNumber = UserDto.DocumentNumber,
                    IdRole = UserDto.IdRole,
                    Address = UserDto.Address,
                };
                              

                await _context.Users.AddAsync(User);

                var Credential = new Credential
                {
                    IdUser = User.Id,
                    EmailIdentifier = UserDto.Email,
                    DocumentIdentifier = UserDto.DocumentNumber,
                    Password = UserDto.Password,

                };
                await _context.Credentials.AddAsync(Credential);
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
                ExistingUser.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

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
