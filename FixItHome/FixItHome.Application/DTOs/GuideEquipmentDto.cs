using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixItHome.Application.DTOs
{
    public class GuideEquipmentDto
    {
        public int Id { get; set; }
        public int GuideId { get; set; }
        public int EquipmentId { get; set; }
        public virtual GuideDto Guide { get; set; }
        public virtual EquipmentDto Equipment { get; set; }
    }
}
