using FixItHome.Domain.Entities;
using FixItHome.Infrastructure.Repositories;

namespace FixItHome.Application.Service
{
    public class EquipmentService
    {
        private readonly UnitOfWork unitOfWork;

        public EquipmentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Application.DTOs.EquipmentDto>> GetAllEquipmentsAsync()
        {
            var entities = await unitOfWork.Equipments.GetAllEquipmentsAsync();

            return entities.Select(e => new Application.DTOs.EquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
            }).ToList();
        }

        public async Task<Application.DTOs.EquipmentDto> GetEquipmentByIdAsync(int id)
        {
            var entity = await unitOfWork.Equipments.GetEquipmentByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new Application.DTOs.EquipmentDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        public async Task AddEquipmentAsync(Application.DTOs.EquipmentDto dto)
        {
            var entity = new  Equipment
            {
                Name = dto.Name,
                Description = dto.Description,
                UseGuide = dto.UseGuide,
                Warnings = dto.Warnings,
                ImageUrl = dto.ImageUrl
            };
            await unitOfWork.Equipments.AddEquipmentAsync(entity);
        }

        public async Task UpdateEquipmentAsync(Application.DTOs.EquipmentDto dto)
        {
            var entity = await unitOfWork.Equipments.GetEquipmentByIdAsync(dto.Id);
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.UseGuide = dto.UseGuide;
            entity.Warnings = dto.Warnings;
            entity.ImageUrl = dto.ImageUrl;

            await unitOfWork.Equipments.UpdateEquipmentAsync(entity);
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            await unitOfWork.Equipments.DeleteEquipmentAsync(id);
        }
    }
}
