using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class CategoryResourceRepository : ICategoryResourceRepository
    {
        private readonly EvoeventosContext _context;
        public CategoryResourceRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<CategoryResource> GetCategoryResource(Guid Id)
        {
            return await _context.CategoryResources.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<CategoryResource>> GetCategoryResources()
        {
            return await _context.CategoryResources.ToListAsync();
        }
        public async Task<bool> CreateCategoryResource(CategoryResource CategoryResource)
        {
            try
            {
                _context.CategoryResources.Add(CategoryResource);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteCategoryResource(Guid Id)
        {
            try
            {
                var CategoryResource = await _context.CategoryResources.FindAsync(Id);
                if (CategoryResource == null)
                {
                    return false;
                }
                _context.CategoryResources.Remove(CategoryResource);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateCategoryResource(Guid Id, CategoryResource UpdatedCategoryResource)
        {
            try
            {
                var existingCategoryResource = await _context.CategoryResources.FindAsync(Id);
                if (existingCategoryResource == null)
                {
                    return false;
                }

                existingCategoryResource.Name = UpdatedCategoryResource.Name;
                existingCategoryResource.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.CategoryResources.Update(existingCategoryResource);
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
