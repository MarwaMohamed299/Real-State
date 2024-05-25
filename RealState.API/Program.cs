using RealState.API.ExceptionHandler;
using RealState.Infrastructure;
using RealState.Application;
using Serilog;
using Microsoft.AspNetCore.Identity;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data.Context;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RealState.Infrastructure.Identity.Models;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    #region Default Services
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    #endregion

    #region Serilog 

    builder.Host.UseSerilog();

    #endregion

    #region Identity
    builder.Services.AddIdentity<User, PlatformRole >(options =>
    {
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 10;
        options.Lockout.MaxFailedAccessAttempts = 3;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    })
        .AddRoles<PlatformRole>()
        .AddEntityFrameworkStores<RealStateContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "default";
        options.DefaultScheme = "default";
        options.DefaultChallengeScheme = "default";
    })
        .AddJwtBearer("default", options =>
    {
        //GenerateKey

        var secretKey = builder.Configuration.GetValue<string>("SecretKey");
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey!);
        var Key = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = Key

        };
    });

    #endregion

    #region Global Services
    builder.Services.AddInfraStructureConfiguration(builder.Configuration);
    builder.Services.AddApplicationConfiguration(builder.Configuration);
    #endregion

    #region Exception Handler
    builder.Services.AddExceptionHandler<ExceptionHandler>();
    builder.Services.AddProblemDetails();
    #endregion

    #region CORS Policy
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllDomains", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
    #endregion
    
    #region Middlewares
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    #region Images Handling
    var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "UploadedFiles");
    //Configuration to let app use static files
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(staticFilesPath),
        RequestPath = "/UploadedFiles" //Localhost:####/(Request Path)/Capture.PNG(Static File Name)

    });
    #endregion

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseCors("AllowAllDomains");

    app.MapControllers();

    app.Run();
    #endregion
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
