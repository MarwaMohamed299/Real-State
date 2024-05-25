using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //Nav Prop
        public int GovernorateId { get; set; }
        public Governorate? Governorate { get; set; }
    }
}
