using FixItHome.Domain.Entities;
using FixItHome.Infrastructure.Repositories;

namespace FixItHome.Application.Service
{
    public class GuideService
    {
        private readonly UnitOfWork unitOfWork;

        public GuideService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Application.DTOs.GuideDto>> GetAllGuidesAsync()
        {
            var entities = await unitOfWork.Guides.GetAllGuidesAsync();

            return entities.Select(e => new Application.DTOs.GuideDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                 Content = e.Content 
            }).ToList();


        }

        public async Task<Application.DTOs.GuideDto> GetGuideByIdAsync(int id)
        {
            var entity = await unitOfWork.Guides.GetGuideByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new Application.DTOs.GuideDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Content = entity.Content
            };
        }

        public async Task AddGuideAsync(Application.DTOs.GuideDto dto)
        {
            var entity = new Guide
            {

                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Content = dto.Content
            };
            await unitOfWork.Guides.AddGuideAsync(entity);
        }

        public async Task UpdateGuideAsync(Application.DTOs.GuideDto dto)
        {
            var entity = await unitOfWork.Guides.GetGuideByIdAsync(dto.Id);
             
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Content = dto.Content;

            await unitOfWork.Guides.UpdateGuideAsync(entity);
        }

        public async Task DeleteGuideAsync(int id)
        {
            await unitOfWork.Guides.DeleteGuideAsync(id);
        }
    }
}
