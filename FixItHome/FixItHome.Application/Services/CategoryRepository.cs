namespace FixItHome.Infrastructure.Repositories
{
    public class CategoryService
    {
        private readonly CategoryRepository repo;
        private readonly UnitOfWork unitOfWork;

        public CategoryService(CategoryRepository repo, UnitOfWork unitOfWork)
        {
            this.repo = repo;
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Domain.Entities.CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await repo.GetAllCategoriesAsync();
            return categories.Select(c => new Domain.Entities.CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Guides = c.Guides.Select(g => new Domain.Entities.GuideDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    UserId = g.UserId
                }).ToList()
            }).ToList();
        }
        public async Task<Domain.Entities.CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await unitOfWork.Categories.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return new Domain.Entities.CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Guides = category.Guides.Select(g => new Domain.Entities.GuideDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    UserId = g.UserId
                }).ToList()
            };
        }
        public async Task AddCategoryAsync(Domain.Entities.CategoryDto category)
        {
            var entity = new Domain.Entities.Category
            {
                Name = category.Name,
                Description = category.Description,
            };
            await unitOfWork.Categories.AddCategoryAsync(entity);
        }

        public async Task UpdateCategoryAsync(Domain.Entities.CategoryDto category)
        {
            var entity = await unitOfWork.Categories.GetCategoryByIdAsync(category.Id);
            entity.Name = category.Name;
            entity.Description = category.Description;

            await unitOfWork.Categories.UpdateCategoryAsync(entity);
        }
        
        public async Task DeleteCategoryAsync(int id)
        {
            await unitOfWork.Categories.DeleteCategoryAsync(id); 
        }
    }
}
