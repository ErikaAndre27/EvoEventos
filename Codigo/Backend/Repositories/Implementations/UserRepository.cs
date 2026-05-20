using BackEvoEventos.Context;
using BackEvoEventos.Dtos;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly EvoeventosContext _context;
        private readonly IRoleRepository _roleRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public UserRepository(EvoeventosContext context, IRoleRepository roleRepository, IDocumentTypeRepository documentTypeRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
            _documentTypeRepository = documentTypeRepository;
        }
        public async Task<User> GetUserById(Guid Id)
        {
            return await _context.Users.Include(u => u.Role).Include(c => c.Credentials).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<User> GetUserByEmail(string Email)
        {
            return await _context.Users.Include(u => u.Role).Include(c => c.Credentials)
        .FirstOrDefaultAsync(x => x.Email == Email);
        }

        public async Task<User> GetUserByDocumentNumber(string DocumentNumber)
        {
            return await _context.Users.Include(u => u.Role).Include(c => c.Credentials)
        .FirstOrDefaultAsync(x => x.DocumentNumber == DocumentNumber);
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }



        public async Task<bool> CreateUser(CreateUserDto UserDto)
        {
            try
            {
                var RolExisting = await _roleRepository.GetRole(UserDto.IdRole);
                var DocumentTypeExisting = await _documentTypeRepository.GetDocumentTypeById(UserDto.IdDocumentType);
                if (RolExisting != null && DocumentTypeExisting != null)
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
                    var HashedPassword = BCrypt.Net.BCrypt.HashPassword(UserDto.Password);
                    var Credential = new Credential
                    {
                        IdUser = User.Id,
                        EmailIdentifier = UserDto.Email,
                        DocumentIdentifier = UserDto.DocumentNumber,
                        Password = HashedPassword,

                    };
                    await _context.Credentials.AddAsync(Credential);
                    await _context.SaveChangesAsync();

                    return true;
                }
                return false;

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
        public async Task<bool> UpdateUser(Guid Id, UpdateUserDto updateDto)
        {
            try
            {
                var ExistingUser = await _context.Users.FindAsync(Id);
                if (ExistingUser == null)
                {
                    return false;
                }
                // Actualizaciones parciales: solo asignar si el campo viene en el DTO
                if (!string.IsNullOrWhiteSpace(updateDto.Names))
                    ExistingUser.Names = updateDto.Names;

                if (!string.IsNullOrWhiteSpace(updateDto.Surnames))
                    ExistingUser.Surnames = updateDto.Surnames;

                if (!string.IsNullOrWhiteSpace(updateDto.Phone))
                    ExistingUser.Phone = updateDto.Phone;

                if (!string.IsNullOrWhiteSpace(updateDto.Address))
                    ExistingUser.Address = updateDto.Address;

                var credential = await _context.Credentials.FirstOrDefaultAsync(c => c.IdUser == ExistingUser.Id);

                // Si actualiza email, verificar y sincronizar credencial
                if (!string.IsNullOrWhiteSpace(updateDto.Email) && updateDto.Email != ExistingUser.Email)
                {
                    // Verifica que el email no exista en otro usuario
                    var emailExists = await _context.Users.AnyAsync(u => u.Email == updateDto.Email && u.Id != ExistingUser.Id);
                    if (emailExists)
                        return false;

                    ExistingUser.Email = updateDto.Email;

                    if (credential != null)
                    {
                        credential.EmailIdentifier = updateDto.Email;
                        credential.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;
                    }
                }

                // Cambio de contraseña: validar contraseña actual y actualizar la credencial
                if (!string.IsNullOrWhiteSpace(updateDto.NewPassword))
                {
                    if (credential == null)
                        return false; // no hay credencial para validar

                    if (string.IsNullOrEmpty(updateDto.CurrentPassword) || !BCrypt.Net.BCrypt.Verify(updateDto.CurrentPassword, credential.Password))
                    {
                        return false; // contraseña actual inválida
                    }

                    var hashed = BCrypt.Net.BCrypt.HashPassword(updateDto.NewPassword);
                    credential.Password = hashed;
                    credential.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;
                }

                ExistingUser.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.Users.Update(ExistingUser);
                if (credential != null)
                    _context.Credentials.Update(credential);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
