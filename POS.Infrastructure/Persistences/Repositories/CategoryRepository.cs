using Microsoft.EntityFrameworkCore;
using SAM.Domain.Entities;
using SAM.Infrastructure.Persistences.Contexts;
using SAM.Infrastructure.Persistences.Interfaces;

namespace SAM.Infrastructure.Persistences.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SAMContext _context;
        public CategoryRepository(SAMContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Category>> ListSelectCategories()
        {
            var categories = await _context.Categories.
                Where(x => x.IsActive == true).AsNoTracking().ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<Category>> ListSelectAllCategories()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();
            return categories;
        }

        public async Task<Category> CategoryById(int categoryId)
        {
            var category = await _context.Categories!.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId.Equals(categoryId));
            return category!;
        }

        public async Task<bool> CreateCategory(Category category)
        {
            category.CreatedDate = DateTime.Now;
            await _context.AddAsync(category);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            category.ModifiedDate = DateTime.Now;
            _context.Update(category);
            _context.Entry(category).Property(x => x.CreatedDate).IsModified = false;
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.CategoryId.Equals(categoryId));
            category!.ModifiedDate = DateTime.Now;
            category!.IsActive = false;
            _context.Update(category);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;

        }
    }
}
