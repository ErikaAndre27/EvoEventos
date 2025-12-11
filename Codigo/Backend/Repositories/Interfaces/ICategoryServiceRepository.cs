using BackEvoEventos.Models;


namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICategoryServiceRepository
    {
        Task<List<CategoryService>> GetCategoryServices();
        Task<CategoryService> GetCategoryService(Guid Id);
        Task<bool> CreateCategoryService(CategoryService CategoryService);
        Task<bool> UpdateCategoryService(Guid Id, CategoryService UpdatedCategoryService); 
        Task<bool> DeleteCategoryService(Guid Id);
    }
}
