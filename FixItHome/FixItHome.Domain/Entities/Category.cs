namespace FixItHome.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Guide> Guides { get; set; } = new List<Guide>();
    }
}
