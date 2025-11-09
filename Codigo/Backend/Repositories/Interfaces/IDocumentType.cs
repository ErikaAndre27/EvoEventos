using BackEvoEventos.Models;

namespace BackEvoEventos.Repositories.Interfaces
{
    public interface IDocumentType
    {
        Task<List<DocumentType>> GetAllDocumentTypes();
        Task<DocumentType> GetDocumentTypeById(Guid Id);
        Task<bool> CreateDocumentType(DocumentType DocumentType);
        Task<bool> UpdateDocumentType(Guid Id, DocumentType UpdateDocumentType);
        Task<bool> DeleteDocumentType(Guid Id);
    }
}
