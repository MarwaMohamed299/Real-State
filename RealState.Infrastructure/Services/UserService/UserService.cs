using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RealState.Application.Contracts.Abstractions.User;
using RealState.Application.Contracts.Models.Login;
using RealState.Application.Contracts.Models.Register;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManger;
        private readonly RealStateContext _realStateContext;
        private readonly IConfiguration _config;

        public UserService(UserManager<User> userManager, RealStateContext realStateContext, IConfiguration configuration)
        {
            _userManger = userManager;
            _realStateContext = realStateContext;
            _config = configuration;
        }

        #region RegisterClient
        public async Task<RegisterResponseDto> RegisterClientAsync(RegisterRequestDto registerDto)
        {
            var newUser = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
            };
            var creationResult = await _userManger.CreateAsync(newUser, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return null!;
            }
            else
            {
                var userRoles = await _userManger.GetRolesAsync(newUser);

                IEnumerable<Claim> claims = [
                    new(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
                    new(ClaimTypes.Name, newUser.UserName),
                    new (ClaimTypes.Email, newUser.Email),
                    //new(ClaimTypes.Role, "Client")

                  ];
                claims = claims.Concat(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));

                await _userManger.AddClaimsAsync(newUser, claims);
                await _userManger.AddToRoleAsync(newUser!, "Client");

                var client = new Client
                {
                    FName = registerDto.FirstName,
                    LName = registerDto.LastName,
                    Nationality = registerDto.Nationality,
                    SSN = registerDto.SSN,
                    UserId = newUser.Id
                };

                _realStateContext.Add(client);
                var res = await _realStateContext.SaveChangesAsync();
                if (res > 0)
                {
                    return new RegisterResponseDto
                    {
                        Email = registerDto.Email,
                        UserName = registerDto.UserName,
                        FirstName = registerDto.FirstName,
                        LastName = registerDto.LastName
                    };
                }
                else
                {
                    await _userManger.DeleteAsync(newUser);
                    return null!;
                }

            };

        }
        #endregion

        #region LogIn
        public async Task<LogInResultDto> LogInAsync(LogInDto credentials)
        {
            LogInResultDto resultDto = new LogInResultDto();

            var User = await _userManger.FindByNameAsync(credentials.UserName);
            if (User == null)
            {
                resultDto.IsSuccess = false;
                resultDto.Message = "User Name Or Password Isn't Correct";
                return resultDto;
            }
            if (await _userManger.IsLockedOutAsync(User))
            {
                resultDto.IsSuccess = false;
                resultDto.Message = "User Is Locked, Try again after 10 minutes";
                return resultDto;
            }
            if (!await _userManger.CheckPasswordAsync(User, credentials.Password))
            {
                await _userManger.AccessFailedAsync(User);
                resultDto.IsSuccess = false;
                resultDto.Message = "User Name Or Password Isn't Correct";
                return resultDto;
            }

            //Key Generation

            var SecretKey = _config["SecretKey"];
            var secretKeyInBytes = Encoding.ASCII.GetBytes(SecretKey!);

            var Key = new SymmetricSecurityKey(secretKeyInBytes);
            //Hashing 
            var generatingToken = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature);
            var userClaims = await _userManger.GetClaimsAsync(User);

            //Generate token
            var jwt = new JwtSecurityToken
                (
                    claims: userClaims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: generatingToken
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(jwt);
            resultDto.IsSuccess = true;
            resultDto.Message = "Login Successfully";
            resultDto.Token = tokenString;
            resultDto.ExpiryDate = jwt.ValidTo;
            return resultDto;
            #endregion
        }
    }

}

