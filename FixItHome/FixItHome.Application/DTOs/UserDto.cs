namespace FixItHome.Domain.Entities
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<GuideDto> Guides { get; set; } = new List<GuideDto>();


    }
}
