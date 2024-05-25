using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Application.Contracts.Abstractions.Services.RequestService;
using RealState.Application.Validators;
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

            

            return services;
        }
    }
}
