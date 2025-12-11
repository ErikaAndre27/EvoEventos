using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICredentialRepository
    {
        Task<Credential?> GetCredentialByIdentifier(string Identifier);
        Task<Credential> GetCredentialByUserId(Guid IdUser);
        Task<bool> UpdateLastLogin(Guid CredentialId);
    }
}

