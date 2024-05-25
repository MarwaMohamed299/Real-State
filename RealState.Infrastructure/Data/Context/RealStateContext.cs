using Azure.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealState.Domain.Entities;
using RealState.Domain.Enums;
using RealState.Infrastructure.Identity.Models;
using Request = RealState.Domain.Entities.Request;
namespace RealState.Infrastructure.Data.Context
{

    public class RealStateContext : IdentityDbContext<User, PlatformRole, string>
    {
        public DbSet<Request> Requests => Set<Request>();
        public DbSet<UnitType> UnitTypes => Set<UnitType>();
        public DbSet<Appartment> Appartments => Set<Appartment>();
        public DbSet<AppartmentArea> AppartmentAreas => Set<AppartmentArea>();
        public DbSet<Auditor> Auditors => Set<Auditor>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Surveyer> Surveyers => Set<Surveyer>();
        public DbSet<UploadFile> UploadFiles => Set<UploadFile>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Governorate> Governorates => Set<Governorate>();
        public DbSet<City> City => Set<City>();

        public RealStateContext(DbContextOptions<RealStateContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Company
            builder.Entity<Company>()
                .HasMany(a => a.Auditors)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            builder.Entity<Company>()
                .HasMany(a => a.Surveyers)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);
            #endregion

            #region Auditor

            builder.Entity<Auditor>()
                .HasMany<Request>()
                .WithOne(a => a.Auditor)
                .HasForeignKey(c => c.AuditorId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Admin
            builder.Entity<Admin>()
               .HasMany<Request>()
               .WithOne(a => a.Admin)
               .HasForeignKey(c => c.AdminId)
               .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Client
            builder.Entity<Client>()
               .HasMany<Request>()
               .WithOne(a => a.Client)
               .HasForeignKey(c => c.ClientId)
               .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Surveyer
            builder.Entity<Surveyer>()
               .HasMany<Request>()
               .WithOne(a => a.Surveyer)
               .HasForeignKey(c => c.SurveyerId)
               .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region UnitType

            builder.Entity<UnitType>()
                .HasMany<Request>()
                .WithOne(r => r.UnitType)
                .HasForeignKey(v => v.UnitTypeId);


            #endregion

            //#region Appartment

            //builder.Entity<Appartment>()
            //    .HasMany<AppartmentArea>()
            //    .WithOne(r => r.Appartment)
            //    .HasForeignKey(v => v.AppartmentId);
            //#endregion


            #region Request

            builder.Entity<Request>()
                .HasOne<Appartment>()
                .WithOne(b => b.Request)
                .HasForeignKey<Appartment>(b => b.RequestId);

            builder.Entity<Request>()
                .HasMany<UploadFile>()
                .WithOne(r => r.Request)
                .HasForeignKey(v => v.RequestId);

            builder.Entity<Request>()
              .HasMany<RequestLog>()
              .WithOne(r => r.Request)
              .HasForeignKey(r => r.RequestId);

            

            #endregion


            #region Seeding

            #region Roles
            var roles = new List<PlatformRole>
            {
                 new PlatformRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new PlatformRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Client",
                NormalizedName = "CLIENT"
            },
            new PlatformRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Surveyer",
                NormalizedName = "SURVEYER"
            },
                new PlatformRole
                {
                    Id= Guid.NewGuid().ToString(),
                    Name = "Auditor",
                    NormalizedName = "AUDITOR"
                }
            };
            #endregion

            #region Company
            var companies = new List<Company>
            {
                new Company
                {
                    Id=1,
                    Name = "Company1"
                }
            };
            #endregion

            #region Users 
            var users = new List<User>
            {
                new User
                {
                    UserName = "Sara",
                    Id = Guid.NewGuid().ToString()
                },
                new User
                {
                    UserName = "Jakson",
                    Id = Guid.NewGuid().ToString()
                },
                new User
                {
                    UserName = "Michael",
                    Id = Guid.NewGuid().ToString()
                },
                new User
                {
                    UserName = "John",
                    Id = Guid.NewGuid().ToString()
                },
            };
            #endregion

            #region Clients
            var Clients = new List<Client> {
                new Client
                {
                    Id =102,
                    FName = "John",
                    LName = "Doe",
                    SSN = "123-45-6789",
                    Nationality = Nationality.Egyptian,
                    UserId = users[0].Id
                },

            };
            #endregion

            #region Admins
            var Admins = new List<Admin> {
                new Admin
                {
                    Id =32,
                    FName = "Sandy",
                    LName = "Doe",
                    Nationality = Nationality.Egyptian,
                    UserId = users[1].Id
                },

            };
            #endregion

            #region Surveyers
            var Surveyers = new List<Surveyer> {
                new Surveyer
                {
                    Id =1,
                    FName = "Suzan",
                    LName = "Doe",
                    Nationality = Nationality.Egyptian,
                    UserId = users[2].Id,
                    CompanyId = companies[0].Id

                },

            };
            #endregion

            #region Auditors
            var auditors = new List<Auditor> {
                new Auditor
                {
                    Id =5,
                    FName = "Jackley",
                    LName = "Doe",
                    Nationality = Nationality.Egyptian,
                    UserId = users[3].Id,
                    CompanyId = companies[0].Id
                },

            };
            #endregion

            #region Requests
            var sampleRequest = new List<Request>
            {
            new Request
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                PhoneNumber = "1234567890",
                //UnitTypeId = 1,
                Area = 100,
                FloorCount = 5,
                OwnerAddress = "123 Main St",
                CityId = 1,
                District = "Zamalek",
                Street = "Nile St",
                Building = "Royal Tower",
                UnitNumber = "A101",
                X = 30.12345f,
                Y = 31.98765f,
                AuditorId = auditors[0].Id,
                ClientId = Clients[0].Id,
                AdminId = Admins[0].Id,
                SurveyerId = Surveyers[0].Id,

                }
            };
            #endregion

            #region Requestlog
            var sampleRequestLog = new List<RequestLog>
            {
                new RequestLog
            {
                Id = 1,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Pending",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 2,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "New",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 3,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Paid",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                 Id = 4,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Assigned To Company",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 5,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Assigned To Surveyer",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 6,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "AppointMent Arrangement",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 7,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Pending For Company Review",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 8,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Pending For User Data Completion",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 9,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Pending For Surveyer Completion",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 10,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Cancelled By User",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 11,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Completed",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
                new RequestLog
            {
                Id = 12,
                UserId = users[0].Id,
                UserType = "Client",
                Status = "Pendingfor Authority Review",
                CreationDate = DateTime.Now,
                RequestId = sampleRequest[0].Id
            },
            };
            #endregion

            builder.Entity<User>().HasData(users);
            builder.Entity<Company>().HasData(companies);
            builder.Entity<Admin>().HasData(Admins);
            builder.Entity<Surveyer>().HasData(Surveyers);
            builder.Entity<PlatformRole>().HasData(roles);
            builder.Entity<Client>().HasData(Clients);
            builder.Entity<Auditor>().HasData(auditors);
            builder.Entity<Request>().HasData(sampleRequest);
            builder.Entity<RequestLog>().HasData(sampleRequestLog);

            #endregion
        }
    }
}
