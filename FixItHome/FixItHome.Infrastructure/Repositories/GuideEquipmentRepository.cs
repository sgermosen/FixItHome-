using FixItHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FixItHome.Infrastructure.Repositories
{
    public class GuideEquipmentRepository
    {
        private readonly FixItHomeApplicationContext context;

        public GuideEquipmentRepository(FixItHomeApplicationContext context)
        {
            this.context = context;
        }
         
        public async Task<List<Domain.Entities.GuideEquipment>> GetAllGuideEquipmentsFromGuideIdAsync(int guideId)
        {
            return await context.GuideEquipments 
                .Include(g => g.Guide) 
                .Include(g => g.Equipment)
                .Where(g => g.GuideId == guideId)
                .ToListAsync();
        }
        
        public async Task<Domain.Entities.GuideEquipment> GetGuideEquipmentByIdAsync(int id)
        {
            return await context.GuideEquipments 
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddGuideEquipmentAsync(Domain.Entities.GuideEquipment guide)
        {
            context.GuideEquipments.Add(guide);
            await context.SaveChangesAsync();
        }
        public async Task UpdateGuideEquipmentAsync(Domain.Entities.GuideEquipment guide)
        {
            context.GuideEquipments.Update(guide);
            await context.SaveChangesAsync();
        }
        public async Task DeleteGuideEquipmentAsync(int id)
        {
            var guide = await context.GuideEquipments.FindAsync(id);
            if (guide != null)
            {
                context.GuideEquipments.Remove(guide);
                await context.SaveChangesAsync();
            }

        }
    }
}
