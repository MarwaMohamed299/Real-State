using RealState.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class Client 
    {
        public int Id { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string SSN { get; set; } = string.Empty;
        public Nationality Nationality { get; set; }
        //NavProp
        public List<Request> Requests = new List<Request>();
        public string UserId { get; set; } = string.Empty;

}
}
