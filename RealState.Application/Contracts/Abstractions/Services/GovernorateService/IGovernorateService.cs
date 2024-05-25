using RealState.Application.Contracts.Models.Cities;
using RealState.Application.Contracts.Models.Governorates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Services.GovernorateService
{
    public interface IGovernorateService
    {
        Task<IEnumerable<GovernorateReadDto>> GetGovernoratesAsync();
        Task<IEnumerable<CityReadDto>> GetCitiesByGovernorateIdAsync(int GovernorateId);
    }
}
