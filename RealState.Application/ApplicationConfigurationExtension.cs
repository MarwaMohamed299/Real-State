using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Application.Contracts.Abstractions.Services.CalculateFees;
using RealState.Application.Contracts.Abstractions.Services.CityService;
using RealState.Application.Contracts.Abstractions.Services.FileServices;
using RealState.Application.Contracts.Abstractions.Services.GovernorateService;
using RealState.Application.Contracts.Abstractions.Services.RequestService;
using RealState.Application.Services.CityService;
using RealState.Application.Services.GovernorateService;
using RealState.Application.Validators;
using RealState.Infrastructure.Services.CalculateFeesService;
using RealState.Infrastructure.Services.FileServices;
using RealState.Infrastructure.Services.RequestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application
{
    public static class ApplicationConfigurationExtension
    { 
        public static IServiceCollection AddApplicationConfiguration
        (
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            #region Validation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion

            #region FileServices
            services.AddScoped<IFileService, FileServices>();

            #endregion

            #region Request Service

            services.AddScoped<IRequestService, RequestService>();

            #endregion

            #region Fees Service
            services.AddScoped<IFeesService, FeesService>();

            #endregion
            #region Governorates  Service

            services.AddScoped<IGovernorateService, GovernorateService>();

            #endregion

            #region City  Service

            services.AddScoped<ICityService, CityServices>();  // Corrected line


            #endregion

            return services;
        }
    }
}
