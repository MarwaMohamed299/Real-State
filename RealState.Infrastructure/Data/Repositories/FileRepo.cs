using Microsoft.EntityFrameworkCore;
using RealState.Application.Contracts.Abstractions.Repositories;
using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using RealState.Infrastructure.Data.Context;
using RealState.Infrastructure.Data.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Data.Repositories
{
    public class FileRepo: GenericRepo<UploadFile>, IFileRepo
    {
        private readonly RealStateContext _dbContext;

        public FileRepo(RealStateContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<UploadFile> GetRequestFiles(int RequestId)
        {
            return _dbContext.Set<UploadFile>()
                .Where(i => i.RequestId == RequestId);
        }

        public void Add(UploadFile file)
        {
            _dbContext.Set<UploadFile>().Add(file);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }



    }
}
