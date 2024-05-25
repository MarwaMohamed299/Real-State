using Microsoft.AspNetCore.Identity;
using RealState.Application.Contracts.Models.Login;
using RealState.Application.Contracts.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.User
{
    public interface IUserService
    {
        Task<RegisterResponseDto> RegisterClientAsync(RegisterRequestDto registerDto);
        Task<LogInResultDto> LogInAsync(LogInDto credentials);
    }
}
