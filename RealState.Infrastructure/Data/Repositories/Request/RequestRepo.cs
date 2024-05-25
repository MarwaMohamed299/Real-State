using Microsoft.EntityFrameworkCore;
using RealState.Application.Contracts.Abstractions.Repositories;
using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data.Context;
using RealState.Infrastructure.Data.Repositories.Generics;


namespace RealState.Infrastructure.Data.Repositories
{
    public class RequestRepo : GenericRepo<Request>, IRequestRepo
    {
        private readonly RealStateContext _dbContext;

        public RequestRepo(RealStateContext context) : base(context)
        {
            _dbContext = context;
        }
        public async Task<IEnumerable<City>> GetCitiesByGovernorateIdAsync(int governorateId)
        {
            return await _dbContext.City
                .Where(c => c.GovernorateId == governorateId)
                .Select(c => new City { Id = c.Id, Name = c.Name })
                .ToListAsync();
        }
        public async Task<IEnumerable<Appartment>> GetAppartmentTypesAsync()
        {
            return await _dbContext.Appartments
                     .ToListAsync();
        }

        public async Task<IEnumerable<UnitType>> GetUnitTypesAsync()
        {
            return await _dbContext.UnitTypes
                     .ToListAsync();
        }

        public async Task<IEnumerable<Governorate>> GetGovernoratesAsync()
        {
            return await _dbContext.Governorates
                     .ToListAsync();
        }
        public async Task<IEnumerable<AppartmentArea>> GetAvailableAppartmentAreasAsync()
        {
            return await _dbContext.AppartmentAreas
                     .ToListAsync();
        }

        public async Task<City> GetCityWithGovernorateAsync(int cityId)
        {
            var city = await _dbContext.City
                .Where(c => c.Id == cityId)
                .Include(c => c.Governorate)
                .FirstOrDefaultAsync();
            return city!;
        }

        public async Task<Request> GetRequestById(int id)
        {
            var request = await _dbContext.Requests.FindAsync(id);
            return request!;
        }
    }
}
