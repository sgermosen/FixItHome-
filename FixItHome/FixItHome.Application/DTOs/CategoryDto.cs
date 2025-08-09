namespace FixItHome.Domain.Entities
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GuideDto> Guides { get; set; } = new List<GuideDto>();
    }
}
