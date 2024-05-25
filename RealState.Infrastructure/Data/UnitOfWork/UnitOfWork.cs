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

        private readonly RealStateContext _dbContext;

        public UnitOfWork(RealStateContext dbcontext,
            IRequestRepo requestRepository,
            IFileRepo fileRepo)
        {
            _dbContext = dbcontext;
            RequestRepo = requestRepository;
            FileRepo = fileRepo;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
