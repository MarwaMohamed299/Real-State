using RealState.Application.Contracts.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Services.CityService
{
    public interface ICityService
    {
        Task<CityWithGovernorateReadDto> GetCitiesWithGovernorates(int id);

    }
}
