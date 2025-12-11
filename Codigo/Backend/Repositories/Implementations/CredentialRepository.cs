using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
        
        public async Task<Credential?> GetCredentialByIdentifier(string Identifier) 
        {
            
            if (Identifier == null) {
                return null;
            }

            return await _context.Credentials.FirstOrDefaultAsync(x => x.EmailIdentifier == Identifier || x.DocumentIdentifier == Identifier);
            
        }


        public async Task<Credential> GetCredentialByUserId(Guid idUser)
        {
            var Credential = await _context.Credentials
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.IdUser == idUser);
                return Credential?? throw new Exception($"Credential not found for user {idUser}"); //si la varibale es Nula se va a ejecutar El Exeption.
        }
        public async Task<bool> UpdateLastLogin(Guid CredentialId)
        {
            var Credential = await _context.Credentials.FindAsync(CredentialId);
            if (Credential == null) return false;
            Credential.LastLogin = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;
            Credential.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;
            await _context.SaveChangesAsync();
            return true;
        }
        //public async Task<bool> DeleteCredential(Guid Id)
        //{
        //    var Credential = await _context.Credentials.FindAsync(Id);
        //    if (Credential == null)
        //        return false;
        //    _context.Credentials.Remove(Credential);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
        
    }
}
