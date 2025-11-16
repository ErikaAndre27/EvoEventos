using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICredentialRepository
    {
        Task<Credential> CreateCredential(Credential Credential);
        Task<Credential> GetCredentialByIdentifierAndType(string Identifier,Guid IdLoggingType); 
        Task<Credential> GetCredentialByUserId(Guid IdUser);
        Task<Credential> GetCredentialByIdentifier(String Identifier);
        Task<bool> UpdateLastLogin(Guid CredentialId);
        Task<bool> DeleteCredential(Guid Id);
        Task<bool> UpdatePassword(Guid credentialId, string NewPassword);
        Task<bool> IdentifierExists(string Identifier, Guid IdLoggingType);
    }
}

