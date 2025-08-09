using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixItHome.Domain.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UseGuide { get; set; }
        public string Warnings { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<GuideEquipment> GuideEquipments { get; set; } = new List<GuideEquipment>();

    }
}
