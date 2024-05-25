using RealState.Application.Contracts.Abstractions.Services.FileServices;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Services.FileServices
{
    public class FileServices : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void UploadFile(UploadFileDTO file)
        {

            var uploadFile = new UploadFile
            {

  
                Name = file.Name,
                FileType = file.FileType,
                //RequestId = file.RequestId,
                Url = file.Url

            };

            _unitOfWork.FileRepo.AddAsync(uploadFile);
            _unitOfWork.FileRepo.SaveChanges();

        }
        public List<GetFileDto> getRequestFiles(int RequestId)
        {

            List<UploadFile> files = _unitOfWork.FileRepo.GetRequestFiles(RequestId).ToList();

            List<GetFileDto> getFiles = files.Select(i => new GetFileDto
            {
                Name = i.Name,
                Url = i.Url,

            }).ToList();

            return getFiles;

        }
    }
    
}
