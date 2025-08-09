using FixItHome.Domain.Entities;
using FixItHome.Infrastructure.Repositories;

namespace FixItHome.Application.Service
{
    public class GuideEquipmentService
    {
        private readonly UnitOfWork unitOfWork;

        public GuideEquipmentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Application.DTOs.GuideEquipmentDto>> GetAllGuideEquipmentsAsync(int guideId)
        {
            var entities = await unitOfWork.GuideEquipments.GetAllGuideEquipmentsFromGuideIdAsync(guideId);

            return entities.Select(e => new Application.DTOs.GuideEquipmentDto
            {
                Id = e.Id,
                GuideId = e.GuideId,
                EquipmentId = e.EquipmentId,
                Equipment = new Application.DTOs.EquipmentDto
                {
                    Id = e.Equipment.Id,
                    Name = e.Equipment.Name,
                    Description = e.Equipment.Description,
                    UseGuide = e.Equipment.UseGuide,
                    Warnings = e.Equipment.Warnings,
                    ImageUrl = e.Equipment.ImageUrl
                },
                Guide = new Application.DTOs.GuideDto
                {
                    Id = e.Guide.Id,
                    Title = e.Guide.Title,
                    Description = e.Guide.Description,
                    UserId = e.Guide.UserId
                },
            }).ToList(); 
        }

        public async Task<Application.DTOs.GuideEquipmentDto> GetGuideEquipmentByIdAsync(int id)
        {
            var entity = await unitOfWork.GuideEquipments.GetGuideEquipmentByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new Application.DTOs.GuideEquipmentDto
            {
                Id = entity.Id,
                GuideId = entity.GuideId,
                EquipmentId = entity.EquipmentId,
                Equipment = new Application.DTOs.EquipmentDto
                {
                    Id = entity.Equipment.Id,
                    Name = entity.Equipment.Name,
                    Description = entity.Equipment.Description,
                    UseGuide = entity.Equipment.UseGuide,
                    Warnings = entity.Equipment.Warnings,
                    ImageUrl = entity.Equipment.ImageUrl
                },
                Guide = new Application.DTOs.GuideDto
                {
                    Id = entity.Guide.Id,
                    Title = entity.Guide.Title,
                    Description = entity.Guide.Description,
                    UserId = entity.Guide.UserId
                },
            };
        }

        public async Task AddGuideEquipmentAsync(Application.DTOs.GuideEquipmentDto dto)
        {
            var entity = new  GuideEquipment
            {
               GuideId = dto.GuideId,
                EquipmentId = dto.EquipmentId,
            };
            await unitOfWork.GuideEquipments.AddGuideEquipmentAsync(entity);
        }

        public async Task UpdateGuideEquipmentAsync(Application.DTOs.GuideEquipmentDto dto)
        {
            var entity = await unitOfWork.GuideEquipments.GetGuideEquipmentByIdAsync(dto.Id);
            entity.GuideId = dto.GuideId;
            entity.EquipmentId = dto.EquipmentId; 

            await unitOfWork.GuideEquipments.UpdateGuideEquipmentAsync(entity);
        }

        public async Task DeleteGuideEquipmentAsync(int id)
        {
            await unitOfWork.GuideEquipments.DeleteGuideEquipmentAsync(id);
        }
    }
}
