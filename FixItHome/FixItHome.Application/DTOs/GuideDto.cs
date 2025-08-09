using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixItHome.Application.DTOs
{
    public class GuideDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; } 
        public int CategoryId { get; set; }   
        public int UserId { get; set; }
        public virtual CategoryDto Category { get; set; }
        public virtual UserDto User { get; set; }
        public virtual ICollection<GuideEquipmentDto> GuideEquipments { get; set; } = new List<GuideEquipmentDto>();
    }
}
