using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixItHome.Domain.Entities
{
    public class Guide
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; } 
        public int CategoryId { get; set; }   
        public int UserId { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<GuideEquipment> GuideEquipments { get; set; } = new List<GuideEquipment>();
    }
}
