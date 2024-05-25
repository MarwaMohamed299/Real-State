using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Models.Cities
{
    public class CityWithGovernorateReadDto
    {
        public int Id { get; set; }
        public string GovernorateName { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
    }
}
