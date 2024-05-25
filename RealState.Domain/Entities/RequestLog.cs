using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        //NavProp
        public int RequestId { get; set; }
        public Request? Request { get; set; }
    }
}
