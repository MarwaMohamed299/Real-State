using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealState.Application.Contracts;
using RealState.Application.Contracts.Abstractions.Repositories;
using RealState.Application.Contracts.Abstractions.Services.CalculateFees;
using RealState.Application.Contracts.Abstractions.Services.FileServices;
using RealState.Application.Contracts.Abstractions.Services.RequestService;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using RealState.Application.Contracts.Abstractions.User;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data;
using RealState.Infrastructure.Data.Context;
using RealState.Infrastructure.Data.Repositories;
using RealState.Infrastructure.Data.UnitOfWork;
using RealState.Infrastructure.Identity.UserService;
using RealState.Infrastructure.Services.CalculateFeesService;
using RealState.Infrastructure.Services.FileServices;
using RealState.Infrastructure.Services.RequestService;


namespace RealState.Infrastructure
{
    public static class InfrastructureConfigureServiceExtension
    {
        public static IServiceCollection AddInfraStructureConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            #region ConnectionString

            var connectionString = configuration.GetConnectionString("RealState");
            services.AddDbContext<RealStateContext>(options => options.UseSqlServer(connectionString));

            #endregion

            #region CustomServices
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Repositories

            services.AddScoped<IRequestRepo, RequestRepo>();
            services.AddScoped<IFileRepo, FileRepo>();
            services.AddScoped<IGovernorateRepo, GovernorateRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            #endregion

           

            return services;
        }
    }
}
