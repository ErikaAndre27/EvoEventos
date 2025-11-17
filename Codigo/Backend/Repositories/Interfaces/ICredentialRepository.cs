using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICredentialRepository
    {
        Task<Credential> CreateCredential(Credential Credential);
        Task<Credential?> GetCredentialByIdentifier(string Identifier);
        Task<Credential> GetCredentialByUserId(Guid IdUser);
        Task<bool> UpdateLastLogin(Guid CredentialId);
        Task<bool> DeleteCredential(Guid Id);
        Task<bool> UpdatePassword(Guid credentialId, string NewPassword);
    }
}

