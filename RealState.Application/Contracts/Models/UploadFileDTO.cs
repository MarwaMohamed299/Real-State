using RealState.Domain.Entities;
using RealState.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Models
{
    public class UploadFileDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public FileType FileType { get; set; }

        //public int RequestId { get; set; }
    }
}
