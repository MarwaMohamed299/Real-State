using Microsoft.EntityFrameworkCore;
using RealState.Application.Contracts.Abstractions.Repositories;
using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data.Context;
using RealState.Infrastructure.Data.Repositories.Generics;


namespace RealState.Infrastructure.Data.Repositories;

public class RequestRepo : GenericRepo<Request>, IRequestRepo
{
    private readonly RealStateContext _dbContext;

    public RequestRepo(RealStateContext context) : base(context)
    {
        _dbContext = context;
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

    
    public async Task<IEnumerable<AppartmentArea>> GetAvailableAppartmentAreasAsync()
    {
        return await _dbContext.AppartmentAreas
                 .ToListAsync();
    }

   

    public async Task<Request> GetRequestById(int id)
    {
        var request = await _dbContext.Requests.FindAsync(id);
        return request!;
    }
}
