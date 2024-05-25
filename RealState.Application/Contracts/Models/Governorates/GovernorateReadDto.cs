using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Models.Governorates
{
    public class GovernorateReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
