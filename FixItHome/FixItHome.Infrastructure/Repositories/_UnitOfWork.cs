using FixItHome.Infrastructure.Data;

namespace FixItHome.Infrastructure.Repositories
{
    public class UnitOfWork
    {
        private readonly FixItHomeApplicationContext context;
        public CategoryRepository Categories { get; }
        public EquipmentRepository Equipments { get; }
        public GuideEquipmentRepository GuideEquipments { get; }
        public GuideRepository Guides { get; }
        public UserRepository Users { get; }
        public UnitOfWork(FixItHomeApplicationContext context,
            CategoryRepository categoryRepository, EquipmentRepository equipmentRepository,
            GuideEquipmentRepository guideEquipmentRepository, UserRepository userRepository,
           GuideRepository guideRepository)
        {
            this.context = context;
            Categories = categoryRepository;
            Equipments = equipmentRepository;
            GuideEquipments = guideEquipmentRepository;
            Users = userRepository;
            Guides = guideRepository;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
