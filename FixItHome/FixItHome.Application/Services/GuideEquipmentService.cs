namespace FixItHome.Infrastructure.Repositories
{
    public class GuideEquipmentService
    {
        private readonly UnitOfWork unitOfWork;

        public GuideEquipmentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Domain.Entities.GuideEquipmentDto>> GetAllGuideEquipmentsAsync(int guideId)
        {
            var entities = await unitOfWork.GuideEquipments.GetAllGuideEquipmentsFromGuideIdAsync(guideId);

            return entities.Select(e => new Domain.Entities.GuideEquipmentDto
            {
                Id = e.Id,
                GuideId = e.GuideId,
                EquipmentId = e.EquipmentId,
                Equipment = new Domain.Entities.EquipmentDto
                {
                    Id = e.Equipment.Id,
                    Name = e.Equipment.Name,
                    Description = e.Equipment.Description,
                    UseGuide = e.Equipment.UseGuide,
                    Warnings = e.Equipment.Warnings,
                    ImageUrl = e.Equipment.ImageUrl
                },
                Guide = new Domain.Entities.GuideDto
                {
                    Id = e.Guide.Id,
                    Title = e.Guide.Title,
                    Description = e.Guide.Description,
                    UserId = e.Guide.UserId
                },
            }).ToList(); 
        }

        public async Task<Domain.Entities.GuideEquipmentDto> GetGuideEquipmentByIdAsync(int id)
        {
            var entity = await unitOfWork.GuideEquipments.GetGuideEquipmentByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new Domain.Entities.GuideEquipmentDto
            {
                Id = entity.Id,
                GuideId = entity.GuideId,
                EquipmentId = entity.EquipmentId,
                Equipment = new Domain.Entities.EquipmentDto
                {
                    Id = entity.Equipment.Id,
                    Name = entity.Equipment.Name,
                    Description = entity.Equipment.Description,
                    UseGuide = entity.Equipment.UseGuide,
                    Warnings = entity.Equipment.Warnings,
                    ImageUrl = entity.Equipment.ImageUrl
                },
                Guide = new Domain.Entities.GuideDto
                {
                    Id = entity.Guide.Id,
                    Title = entity.Guide.Title,
                    Description = entity.Guide.Description,
                    UserId = entity.Guide.UserId
                },
            };
        }

        public async Task AddGuideEquipmentAsync(Domain.Entities.GuideEquipmentDto dto)
        {
            var entity = new Domain.Entities.GuideEquipment
            {
               GuideId = dto.GuideId,
                EquipmentId = dto.EquipmentId,
            };
            await unitOfWork.GuideEquipments.AddGuideEquipmentAsync(entity);
        }

        public async Task UpdateGuideEquipmentAsync(Domain.Entities.GuideEquipmentDto dto)
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
