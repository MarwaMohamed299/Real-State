using Microsoft.EntityFrameworkCore;
using RealState.Application.Contracts.Abstractions;
using RealState.Application.Contracts.Abstractions.Repositories;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data.Context;


namespace RealState.Infrastructure.Data;

public class GovernorateRepo : IGovernorateRepo
{
    private readonly RealStateContext _dbContext;

    public GovernorateRepo(RealStateContext realStateContext)  
    {
        _dbContext = realStateContext;
    }
    public async Task<IEnumerable<City>> GetCitiesByGovernorateIdAsync(int governorateId)
    {
        return await _dbContext.City
            .Where(c => c.GovernorateId == governorateId)
            .Select(c => new City { Id = c.Id, Name = c.Name })
            .ToListAsync();
    }
    public async Task<IEnumerable<Governorate>> GetGovernoratesAsync()
    {
        return await _dbContext.Governorates
                 .ToListAsync();
    }
}
