using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class Appartment 
    {
        public int Id { get; set; }
        public string AppartmentType { get; set; } = string.Empty;
        public List<AppartmentArea> AppartmentAreas { get; set; } = new List<AppartmentArea>();
        public int RequestId { get; set; }
        public  Request? Request { get; set; }
    }
}
