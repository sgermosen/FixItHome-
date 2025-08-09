using FixItHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FixItHome.Infrastructure.Repositories
{
    public class GuideRepository
    {
        private readonly FixItHomeApplicationContext context;

        public GuideRepository(FixItHomeApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Domain.Entities.Guide>> GetAllGuidesAsync()
        {
            return await context.Guides
                .Include(g => g.User)
                .Include(g => g.GuideEquipments).ThenInclude(ge => ge.Equipment)
                .ToListAsync();
        }
        public async Task<Domain.Entities.Guide> GetGuideByIdAsync(int id)
        {
            return await context.Guides
                .Include(g => g.User)
                .Include(g => g.GuideEquipments).ThenInclude(ge => ge.Equipment)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task AddGuideAsync(Domain.Entities.Guide guide)
        {
            context.Guides.Add(guide);
            
        }
        public async Task UpdateGuideAsync(Domain.Entities.Guide guide)
        {
            context.Guides.Update(guide);
            
        }
        public async Task DeleteGuideAsync(int id)
        {
            var guide = await context.Guides.FindAsync(id);
            if (guide != null)
            {
                context.Guides.Remove(guide);
                
            }

        }
    }
}
