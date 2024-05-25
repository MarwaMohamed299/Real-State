using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class AppartmentArea
    {
        public int Id { get; set; }
        public string AvailableAppartmentAreas { get; set; } = string.Empty;
        public Appartment? Appartment { get; set; } 
    }
}
