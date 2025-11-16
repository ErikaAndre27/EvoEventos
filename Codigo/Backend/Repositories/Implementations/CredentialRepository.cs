using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEvoEventos.Repositories.Implementations
{
    public class CredentialRepository : ICredentialRepository
    {
        private readonly EvoeventosContext _context;

        public CredentialRepository(EvoeventosContext context)
        {
            _context = context;
        }
        
        public async Task<Credential> GetCredentialByIdentifier(string Identifier) 
        {
            return await _context.Credentials.FirstOrDefaultAsync(x => x.Identifier == Identifier);
        }

        public async Task<Credential> CreateCredential(Credential Credential)
        {
            await _context.Credentials.AddAsync(Credential);
            await _context.SaveChangesAsync();
            return Credential;
        }

        public async Task<Credential> GetCredentialByIdentifier(string Identifier)
        {
            return await _context.Credentials.FirstOrDefaultAsync(x => x.Identifier == Identifier);
        }

        public async Task<Credential> GetCredentialByIdentifierAndType(string Identifier, Guid IdLogginType)
        {
           var Credential = await _context.Credentials
                .Include(c => c.User)
                .Include(c => c.LoggingType)
                .FirstOrDefaultAsync(c => c.Identifier == Identifier && c.IdLoggingType == IdLogginType);
                 return Credential?? throw new Exception($"Credential not found for identifier {Identifier} and type {IdLogginType}");
        }

        public async Task<Credential> GetCredentialByUserId(Guid idUser)
        {
            var Credential = await _context.Credentials
                .Include(c => c.User)
                .Include(c => c.LoggingType)
                .FirstOrDefaultAsync(c => c.IdUser == idUser);
                return Credential?? throw new Exception($"Credential not found for user {idUser}"); //si la varibale es Nula se va a ejecutar El Exeption.
        }
        public async Task<bool> UpdateLastLogin(Guid CredentialId)
        {
            var Credential = await _context.Credentials.FindAsync(CredentialId);
            if (Credential == null) return false;
            Credential.LastLogin = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCredential(Guid Id)
        {
            var Credential = await _context.Credentials.FindAsync(Id);
            if (Credential == null)
                return false;
            _context.Credentials.Remove(Credential);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdatePassword(Guid credentialId, string newPassword)
        {
            var Credential = await _context.Credentials.FindAsync(credentialId);
            if (Credential == null) return false;
            Credential.Password = newPassword;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> IdentifierExists(string Identifier, Guid IdLoggingType)
        {
            return await _context.Credentials.AnyAsync(c => c.Identifier == Identifier && c.IdLoggingType == IdLoggingType);
        }
    }
}
