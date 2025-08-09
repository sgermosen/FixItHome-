using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixItHome.Domain.Entities
{
    public class GuideEquipment
    {
        public int Id { get; set; }
        public int GuideId { get; set; }
        public int EquipmentId { get; set; }
        public virtual Guide Guide { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
