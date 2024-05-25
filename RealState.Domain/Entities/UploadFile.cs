using RealState.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class UploadFile
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public FileType FileType { get; set; }

        //FK
        public int RequestId { get; set; }

        //Navigation Prop
        public Request? Request { get; set; }

    }
}
