using Microsoft.AspNetCore.Http;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts
{
    public interface IFileUploadService
    {
        Task<UploadFile> UploadFileAsync(IFormFile file);
    }
}
