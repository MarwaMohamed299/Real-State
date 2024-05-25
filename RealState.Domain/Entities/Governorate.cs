using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class Governorate
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<City> Cities { get; set; } = new List<City>();
    }
}
