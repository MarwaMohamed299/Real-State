using Microsoft.EntityFrameworkCore;
using RealState.Application.Contracts.Abstractions.Repositories;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Data;

public class CityRepo : ICityRepo
{
    private readonly RealStateContext _dbContext;

    public CityRepo(RealStateContext realStateContext)
    {
        _dbContext = realStateContext;

    }
    public async Task<City> GetCityWithGovernorateAsync(int cityId)
    {
        var city = await _dbContext.City
            .Where(c => c.Id == cityId)
            .Include(c => c.Governorate)
            .FirstOrDefaultAsync();
        return city!;
    }
}



