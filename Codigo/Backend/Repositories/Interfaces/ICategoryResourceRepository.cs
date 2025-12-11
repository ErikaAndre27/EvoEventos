using BackEvoEventos.Models;


namespace BackEvoEventos.Repositories.Interfaces
{
    public interface ICategoryResourceRepository
    {
        Task<List<CategoryResource>> GetCategoryResources();
        Task<CategoryResource> GetCategoryResource(Guid Id);
        Task<bool> CreateCategoryResource(CategoryResource CategoryResource);
        Task<bool> UpdateCategoryResource(Guid Id, CategoryResource UpdatedCategoryResource); 
        Task<bool> DeleteCategoryResource(Guid Id);
    }
}
