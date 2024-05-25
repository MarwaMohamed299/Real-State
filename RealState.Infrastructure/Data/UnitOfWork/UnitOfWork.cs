using RealState.Application.Contracts.Abstractions.Repositories;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using RealState.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRequestRepo RequestRepo{ get; }
        public IFileRepo FileRepo { get; }
        public IGovernorateRepo GovernorateReo { get; }

        public ICityRepo CityRepo { get; }

        private readonly RealStateContext _dbContext;

        public UnitOfWork(RealStateContext dbcontext,
            IRequestRepo requestRepository,
            IFileRepo fileRepo,
            IGovernorateRepo governorateReo,
            ICityRepo cityRepo)
        {
            _dbContext = dbcontext;
            RequestRepo = requestRepository;
            FileRepo = fileRepo;
            GovernorateReo = governorateReo;
            CityRepo = cityRepo;
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
