namespace FixItHome.Infrastructure.Repositories
{
    public class EquipmentService
    {
        private readonly UnitOfWork unitOfWork;

        public EquipmentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Domain.Entities.EquipmentDto>> GetAllEquipmentsAsync()
        {
            var entities = await unitOfWork.Equipments.GetAllEquipmentsAsync();

            return entities.Select(e => new Domain.Entities.EquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
            }).ToList();
        }

        public async Task<Domain.Entities.EquipmentDto> GetEquipmentByIdAsync(int id)
        {
            var entity = await unitOfWork.Equipments.GetEquipmentByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new Domain.Entities.EquipmentDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        public async Task AddEquipmentAsync(Domain.Entities.EquipmentDto dto)
        {
            var entity = new Domain.Entities.Equipment
            {
                Name = dto.Name,
                Description = dto.Description,
                UseGuide = dto.UseGuide,
                Warnings = dto.Warnings,
                ImageUrl = dto.ImageUrl
            };
            await unitOfWork.Equipments.AddEquipmentAsync(entity);
        }

        public async Task UpdateEquipmentAsync(Domain.Entities.EquipmentDto dto)
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
