using RealState.Application.Contracts.Abstractions.Services.CityService;
using RealState.Application.Contracts.Abstractions.Services.GovernorateService;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using RealState.Application.Contracts.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Services.CityService
{
    public class CityServices : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<CityWithGovernorateReadDto> GetCitiesWithGovernorates(int id)
        {
            var city = await _unitOfWork.CityRepo.GetCityWithGovernorateAsync(id);
            var dto = new CityWithGovernorateReadDto
            {
                CityName = city.Name,
                Id = city.Id,
                GovernorateName = city.Governorate!.Name
            };

            return dto;
        }
    }
}
