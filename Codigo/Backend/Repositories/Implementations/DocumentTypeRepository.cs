using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class DocumentTypeRepository: IDocumentTypeRepository
    {
        private readonly EvoeventosContext _context;
        public DocumentTypeRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<DocumentType> GetDocumentTypeById(Guid Id)
        {
            return await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<DocumentType>> GetAllDocumentTypes()
        {
            return await _context.DocumentTypes.ToListAsync();
        }
        public async Task<bool> CreateDocumentType(DocumentType DocumentType)
        {
            try
            {
                _context.DocumentTypes.Add(DocumentType);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteDocumentType(Guid Id)
        {
            try
            {
                var DocumentType = await _context.DocumentTypes.FindAsync(Id);
                if (DocumentType == null)
                {
                    return false;
                }
                _context.DocumentTypes.Remove(DocumentType);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateDocumentType(Guid Id, DocumentType UpdateDocumentType)
        {
            try
            {
                var ExistingDocumentType = await _context.DocumentTypes.FindAsync(Id);
                if (ExistingDocumentType == null)
                {
                    return false;
                }

                ExistingDocumentType.Name = ExistingDocumentType.Name;
                ExistingDocumentType.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.DocumentTypes.Update(ExistingDocumentType);
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
