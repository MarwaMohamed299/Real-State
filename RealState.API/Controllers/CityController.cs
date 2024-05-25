using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.Contracts.Abstractions.Services.CityService;
using RealState.Application.Contracts.Models.Cities;

namespace RealState.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        [Route("Get-Governorate-By-City-Id")]
        public async Task<ActionResult<IEnumerable<CityReadDto>>> GetGovrnorateByCityId(int cityId)
        {
            var result = await _cityService.GetCitiesWithGovernorates(cityId);
            return Ok(result);
        }
    }
}
