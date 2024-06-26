﻿using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Repositories
{
    public interface IFileRepo : GenericRepo<UploadFile>
    {

        IEnumerable<UploadFile> GetRequestFiles(int RequestId);

        public void Add(UploadFile file);


        public int SaveChanges();
    }
}
