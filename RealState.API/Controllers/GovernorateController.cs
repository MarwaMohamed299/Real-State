using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.Contracts.Abstractions.Services.GovernorateService;
using RealState.Application.Contracts.Models.Cities;
using RealState.Application.Contracts.Models.Governorates;
using RealState.Application.Services.GovernorateService;

namespace RealState.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernorateController : ControllerBase
    {
        private readonly IGovernorateService _governirateService;

        public GovernorateController( IGovernorateService governorateService)
        {
            _governirateService = governorateService;
        }
        [HttpGet]
        [Route("Get-Governorates")]
        public async Task<ActionResult<IEnumerable<GovernorateReadDto>>> GetAllGovernoratesAsync()
        {
            var result = await _governirateService.GetGovernoratesAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("Get-Cities-in-Governorate-ByGovernorateId")]
        public async Task<ActionResult<IEnumerable<CityReadDto>>> GetCitiesByGovernorateIdAsync(int governorateId)
        {
            var result = await _governirateService.GetCitiesByGovernorateIdAsync(governorateId);
            return Ok(result);
        }
    }
}
