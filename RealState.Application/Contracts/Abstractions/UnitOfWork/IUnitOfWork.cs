using RealState.Application.Contracts.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRequestRepo RequestRepo { get; }
        public IFileRepo FileRepo { get; }
        public IGovernorateRepo GovernorateReo { get; }
        public ICityRepo CityRepo { get; }

        Task SaveChangesAsync();
    }
}
