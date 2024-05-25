using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //NavProp
        public List<Auditor> Auditors = new List<Auditor>();
        public List<Surveyer> Surveyers = new List<Surveyer>();
        
    }
}
