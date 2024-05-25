using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Repositories
{
    public interface IRequestRepo:IGenericRepo<Request>
    {
        Task<IEnumerable<City>> GetCitiesByGovernorateIdAsync(int governorateId);
        Task<IEnumerable<Governorate>> GetGovernoratesAsync();
        Task<City> GetCityWithGovernorateAsync(int cityId);
        Task<IEnumerable<Appartment>> GetAppartmentTypesAsync();
        Task<IEnumerable<UnitType>> GetUnitTypesAsync();
        Task<IEnumerable<AppartmentArea>> GetAvailableAppartmentAreasAsync();
        Task<Request> GetRequestById(int RequestId);
    }
}
