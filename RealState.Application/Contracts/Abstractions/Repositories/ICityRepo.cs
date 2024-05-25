using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Repositories
{
    public interface ICityRepo
    {
        Task<City> GetCityWithGovernorateAsync(int cityId);

    }
}
