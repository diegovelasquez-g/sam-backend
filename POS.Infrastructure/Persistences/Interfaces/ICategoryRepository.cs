using SAM.Domain.Entities;

namespace SAM.Infrastructure.Persistences.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<IEnumerable<Category>> ListSelectAllCategories();
        Task<Category> CategoryById(int categoryId);
        Task<bool> CreateCategory(Category category);
        Task<bool> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int categoryId);

    }
}
