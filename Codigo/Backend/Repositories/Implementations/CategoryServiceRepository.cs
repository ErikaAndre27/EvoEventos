using BackEvoEventos.Context;
using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEvoEventos.Repositories.Implementations
{
    public class CategoryServiceRepository : ICategoryServiceRepository
    {
        private readonly EvoeventosContext _context;
        public CategoryServiceRepository(EvoeventosContext context)
        {
            _context = context;
        }
        public async Task<CategoryService> GetCategoryService(Guid Id)
        {
            return await _context.CategoryServices.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<CategoryService>> GetCategoryServices()
        {
            return await _context.CategoryServices.ToListAsync();
        }
        public async Task<bool> CreateCategoryService(CategoryService CategoryService)
        {
            try
            {
                _context.CategoryServices.Add(CategoryService);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }
        }
        public async Task<bool> DeleteCategoryService(Guid Id)
        {
            try
            {
                var CategoryService = await _context.CategoryServices.FindAsync(Id);
                if (CategoryService == null)
                {
                    return false;
                }
                _context.CategoryServices.Remove(CategoryService);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message.ToString());
            }

        }
        public async Task<bool> UpdateCategoryService(Guid Id, CategoryService UpdatedCategoryService)
        {
            try
            {
                var existingCategoryService = await _context.CategoryServices.FindAsync(Id);
                if (existingCategoryService == null)
                {
                    return false;
                }

                existingCategoryService.Name = UpdatedCategoryService.Name;
                existingCategoryService.UpdatedAt = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;

                _context.CategoryServices.Update(existingCategoryService);
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
