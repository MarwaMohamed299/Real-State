using RealState.Application.Contracts.Abstractions.Services.GovernorateService;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using RealState.Application.Contracts.Models.Cities;
using RealState.Application.Contracts.Models.Governorates;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Services.GovernorateService
{
    public class GovernorateService: IGovernorateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GovernorateService( IUnitOfWork unitOfWork  )
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CityReadDto>> GetCitiesByGovernorateIdAsync(int GovernorateId)
        {
            IEnumerable<City> cityReadDtos = await _unitOfWork.GovernorateReo.GetCitiesByGovernorateIdAsync(GovernorateId);
            return cityReadDtos.Select(c => new CityReadDto
            {
                Id = c.Id,
                Name = c.Name
            });

        }
        public async Task<IEnumerable<GovernorateReadDto>> GetGovernoratesAsync()
        {
            IEnumerable<Governorate> governorateReadDtos = await _unitOfWork.GovernorateReo.GetGovernoratesAsync();
            return governorateReadDtos.Select(c => new GovernorateReadDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
