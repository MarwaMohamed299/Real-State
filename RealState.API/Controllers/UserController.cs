using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.Contracts.Abstractions.User;
using RealState.Application.Contracts.Models.Login;
using RealState.Application.Contracts.Models.Register;

namespace RealState.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Register-Client")]
        public async Task<ActionResult<RegisterResponseDto>> RegisterAsync(RegisterRequestDto registerDto)
        {
            var result = await _userService.RegisterClientAsync(registerDto);
            return Ok(result);

        }

        [HttpPost]
        [Route("Login-Client")]
        public async Task<ActionResult<LogInResultDto>> LoginAsync(LogInDto credentials)
        {
            var result = await _userService.LogInAsync(credentials);
            return Ok(result);
        }


    }
}
