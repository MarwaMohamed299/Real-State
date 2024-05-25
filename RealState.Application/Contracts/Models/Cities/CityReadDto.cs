using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Models.Cities
{
    public class CityReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
