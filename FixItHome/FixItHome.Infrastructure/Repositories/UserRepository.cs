using FixItHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FixItHome.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly FixItHomeApplicationContext context;

        public UserRepository(FixItHomeApplicationContext context)
        {
            this.context = context;
        }
        public async Task<List<Domain.Entities.User>> GetAllUsersAsync()
        {
            return await context.Users 
                .Include(g => g.Guides).ThenInclude(ge => ge.GuideEquipments).ThenInclude(ge => ge.Equipment)
                .ToListAsync();
        }

        public async Task<Domain.Entities.User> GetUserByIdAsync(int id)
        {
            return await context.Users.Include(g => g.Guides).ThenInclude(ge => ge.GuideEquipments).ThenInclude(ge => ge.Equipment)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task AddUserAsync(Domain.Entities.User guide)
        {
            context.Users.Add(guide);
            
        }
        public async Task UpdateUserAsync(Domain.Entities.User guide)
        {
            context.Users.Update(guide);
            
        }
        public async Task DeleteUserAsync(int id)
        {
            var guide = await context.Users.FindAsync(id);
            if (guide != null)
            {
                context.Users.Remove(guide);
                
            }

        }
    }
}
