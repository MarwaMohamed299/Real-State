using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Models
{
    public class RequestReadDto
    {
        public int UnitTypeId { get; set; }
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
        public int ClientId { get; set; }
        public int Id { get; set; }
    }
}
