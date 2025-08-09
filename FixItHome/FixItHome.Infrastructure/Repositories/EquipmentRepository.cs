using FixItHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FixItHome.Infrastructure.Repositories
{
    public class EquipmentRepository
    {
        private readonly FixItHomeApplicationContext context;

        public EquipmentRepository(FixItHomeApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Domain.Entities.Equipment>> GetAllEquipmentsAsync()
        {
            return await context.Equipments
                .Include(g => g.GuideEquipments).ThenInclude(ge => ge.Guide) 
                .ToListAsync();
        }
        public async Task<Domain.Entities.Equipment> GetEquipmentByIdAsync(int id)
        {
            return await context.Equipments 
                .Include(g => g.GuideEquipments).ThenInclude(ge => ge.Guide)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task AddEquipmentAsync(Domain.Entities.Equipment guide)
        {
            context.Equipments.Add(guide);
            await context.SaveChangesAsync();
        }
        public async Task UpdateEquipmentAsync(Domain.Entities.Equipment guide)
        {
            context.Equipments.Update(guide);
            await context.SaveChangesAsync();
        }
        public async Task DeleteEquipmentAsync(int id)
        {
            var guide = await context.Equipments.FindAsync(id);
            if (guide != null)
            {
                context.Equipments.Remove(guide);
                await context.SaveChangesAsync();
            }

        }
    }
}
