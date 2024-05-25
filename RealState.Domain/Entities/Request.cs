using RealState.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Domain.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? AppartmentArea { get; set; }
        public int? FloorCount { get; set; }
        public decimal Area { get; set; }
        public string? OwnerAddress { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string? Building { get; set; } = string.Empty;
        public string? UnitNumber { get; set; } = string.Empty;
        public float X { get; set; }
        public float Y { get; set; }
        public float? Fees { get; set; }


        ////NavProp
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public int? AuditorId { get; set; }
        public Auditor? Auditor { get; set; }
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }
        public int? SurveyerId { get; set; }
        public Surveyer? Surveyer { get; set; }
        public List<UploadFile> UploadFile = new List<UploadFile>();
        public List<RequestLog> RequestLogs = new List<RequestLog>();
        public int? UnitTypeId { get; set; }
        public UnitType? UnitType { get; set; }
        public Appartment? Appartment { get; set; }

    }

}
