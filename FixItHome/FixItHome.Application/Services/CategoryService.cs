using FixItHome.Domain.Entities;
using FixItHome.Infrastructure.Repositories;

namespace FixItHome.Application.Service
{
    public class CategoryService
    {
        private readonly UnitOfWork unitOfWork;

        public CategoryService( UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Application.DTOs.CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await unitOfWork.Categories.GetAllCategoriesAsync();
            return categories.Select(c => new Application.DTOs.CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Guides = c.Guides.Select(g => new Application.DTOs.GuideDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    UserId = g.UserId
                }).ToList()
            }).ToList();
        }
        public async Task<Application.DTOs.CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await unitOfWork.Categories.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return new Application.DTOs.CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Guides = category.Guides.Select(g => new Application.DTOs.GuideDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    UserId = g.UserId
                }).ToList()
            };
        }
        public async Task AddCategoryAsync(Application.DTOs.CategoryDto category)
        {
            var entity = new Category
            {
                Name = category.Name,
                Description = category.Description,
            };
            await unitOfWork.Categories.AddCategoryAsync(entity);
        }

        public async Task UpdateCategoryAsync(Application.DTOs.CategoryDto category)
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
