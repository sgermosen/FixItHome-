using FixItHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FixItHome.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly FixItHomeApplicationContext context;

        public CategoryRepository(FixItHomeApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Domain.Entities.Category>> GetAllCategoriesAsync()
        {
            return await context.Categories
                .Include(g => g.Guides) 
                .ToListAsync();
        }
        public async Task<Domain.Entities.Category> GetCategoryByIdAsync(int id)
        {
            return await context.Categories
                .Include(g => g.Guides) 
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task AddCategoryAsync(Domain.Entities.Category guide)
        {
            context.Categories.Add(guide); 
        }
        public async Task UpdateCategoryAsync(Domain.Entities.Category guide)
        {
            context.Categories.Update(guide); 
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var guide = await context.Categories.FindAsync(id);
            if (guide != null)
            {
                context.Categories.Remove(guide); 
            }

        }
    }
}
