namespace FixItHome.Infrastructure.Repositories
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Domain.Entities.UserDto>> GetAllUsersAsync()
        {
            var entities = await unitOfWork.Users.GetAllUsersAsync();

            return entities.Select(e => new Domain.Entities.UserDto
            {
                Id = e.Id,
                Email = e.Email,
                Name = e.Name,
                Guides = e.Guides.Select(g => new Domain.Entities.GuideDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    UserId = g.UserId
                }).ToList(),
                LastName = e.LastName,
                Username = e.Username  
            }).ToList();
        }

        public async Task<Domain.Entities.UserDto> GetUserByIdAsync(int id)
        {
            var entity = await unitOfWork.Users.GetUserByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new Domain.Entities.UserDto
            {
                Id = entity.Id,
                Email = entity.Email,
                Name = entity.Name,
                Guides = entity.Guides.Select(g => new Domain.Entities.GuideDto
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    UserId = g.UserId
                }).ToList(),
                LastName = entity.LastName,
                Username = entity.Username
            };
        }

        public async Task AddUserAsync(Domain.Entities.UserDto dto)
        {
            var entity = new Domain.Entities.User
            { 
                Email = dto.Email,
                Name = dto.Name, 
                LastName = dto.LastName,
                Username = dto.Username
            };
            await unitOfWork.Users.AddUserAsync(entity);
        }

        public async Task UpdateUserAsync(Domain.Entities.UserDto dto)
        {
            var entity = await unitOfWork.Users.GetUserByIdAsync(dto.Id);
            entity.Email = dto.Email;
            entity.Name = dto.Name;
            entity.LastName = dto.LastName;
            entity.Username = dto.Username;

            await unitOfWork.Users.UpdateUserAsync(entity);
        }

        public async Task DeleteUserAsync(int id)
        {
            await unitOfWork.Users.DeleteUserAsync(id);
        }
    }
}
