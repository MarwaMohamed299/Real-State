using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Services.FileServices
{
    public interface IFileService
    {
        void UploadFile(SaveFileDto file);
        List<GetFileDto> getRequestFiles(int RequestId);


    }
}
