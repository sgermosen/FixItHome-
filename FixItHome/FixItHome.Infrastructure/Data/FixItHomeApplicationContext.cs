using FixItHome.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixItHome.Infrastructure.Data
{
    public class FixItHomeApplicationContext: DbContext
    {
        public FixItHomeApplicationContext(DbContextOptions o) : base(o) { }
  

        public DbSet<Domain.Entities.Guide> Guides { get; set; }
        public DbSet<GuideEquipment> GuideEquipments { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
