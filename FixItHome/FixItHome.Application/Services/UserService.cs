using FixItHome.Domain.Entities;
using FixItHome.Infrastructure.Repositories;

namespace FixItHome.Application.Service
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Application.DTOs.UserDto>> GetAllUsersAsync()
        {
            var entities = await unitOfWork.Users.GetAllUsersAsync();

            return entities.Select(e => new Application.DTOs.UserDto
            {
                Id = e.Id,
                Email = e.Email,
                Name = e.Name,
                Guides = e.Guides.Select(g => new Application.DTOs.GuideDto
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

        public async Task<Application.DTOs.UserDto> GetUserByIdAsync(int id)
        {
            var entity = await unitOfWork.Users.GetUserByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            return new Application.DTOs.UserDto
            {
                Id = entity.Id,
                Email = entity.Email,
                Name = entity.Name,
                Guides = entity.Guides.Select(g => new Application.DTOs.GuideDto
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

        public async Task AddUserAsync(Application.DTOs.UserDto dto)
        {
            var entity = new  User
            { 
                Email = dto.Email,
                Name = dto.Name, 
                LastName = dto.LastName,
                Username = dto.Username
            };
            await unitOfWork.Users.AddUserAsync(entity);
        }

        public async Task UpdateUserAsync(Application.DTOs.UserDto dto)
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
