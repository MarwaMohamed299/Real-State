using Microsoft.AspNetCore.Mvc;
using RealState.Application.Contracts;
using RealState.Application.Contracts.Abstractions.Services.FileServices;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using RealState.Application.Contracts.Models;
using RealState.Domain.Entities;
using RealState.Domain.Enums;

namespace RealState.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;

        public FileController(IConfiguration configuration, IFileService fileService)
        {
            _configuration = configuration;
            _fileService = fileService;
        }




        [HttpPost]
        [Route("UploadFile")]
        public ActionResult<string> UploadFile( [FromForm] UploadFileDTO file )
        {

            
            #region Extention Checking

            var extension = Path.GetExtension(file.File.FileName);

            //Change in appsettings.json
            var extensionList = _configuration.GetSection("AllowedFileExtenstions").Get<string[]>();

            bool isExtensionAllowed = extensionList!.Contains(extension,
                StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest("Format not allowed");
            }
            #endregion

            #region Length Checking

            bool isSizeAllowed = file.File.Length is > 0 and < 5_000_000; //File Size (Minimum: >0 and Max: 5MB)

            if (!isSizeAllowed)
            {
                return BadRequest("Size is Larger than allowed size");
            }
            #endregion

            #region Storing File
            var generatedFileName = $"{Guid.NewGuid()}{extension}";
            var savedFilePath = Path.Combine(Environment.CurrentDirectory, "UploadedFiles", extension, generatedFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(savedFilePath)!); // Ensure the directory exists

            using (var stream = new FileStream(savedFilePath, FileMode.Create))
            {
                file.File.CopyTo(stream);
            }
            #endregion

            #region URL Generating
            var url = $"{Request.Scheme}://{Request.Host}/UploadedFiles/{extension}/{generatedFileName}";
            #endregion

            var newFile = new SaveFileDto
            {
                Name = generatedFileName,
                RequestId = file.RequestId,
                Url = url,
                FileType = FileType.Contract
            };

            _fileService.UploadFile(newFile);
            return Ok("File Uploaded Successfully!");
        }

        [HttpGet]
        [Route("GetFile")]
        public ActionResult<GetFileDto> GetFile(int RequestId)
        {
            var files = _fileService.getRequestFiles(RequestId);

            return Ok(files);
        }
    }
}
