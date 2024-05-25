using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealState.Application.Contracts.Abstractions.Services.CalculateFees;
using RealState.Application.Contracts.Abstractions.Services.FileServices;
using RealState.Application.Contracts.Abstractions.Services.RequestService;
using RealState.Application.Contracts.Models;
using RealState.Application.Contracts.Models.Appartments;
using RealState.Application.Contracts.Models.Buildings;
using RealState.Application.Contracts.Models.Cities;
using RealState.Application.Contracts.Models.Governorates;
using RealState.Domain.Enums;

namespace RealState.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IFeesService _FeesService;
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        public RequestController(IRequestService requestService, IFeesService feesService, IConfiguration configuration, IFileService fileService)
        {
            _requestService = requestService;
            _FeesService = feesService;
            _configuration = configuration;
            _fileService = fileService;
        }
        [HttpGet]
        [Route("Get-UnitTypes")]
        public async Task<ActionResult<IEnumerable<UnitTypeReadDto>>> GetUnitTypesAsync()
        {
            var result = await _requestService.GetUnittypesAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("Get-Appartments")]
        public async Task<ActionResult<IEnumerable<AppartmentReadDto>>> GetAppartmentyTypesAsync()
        {
            var result = await _requestService.GetAppartmenttypesAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("Get-AppartmentsAreas")]
        public async Task<ActionResult<IEnumerable<AppartmentReadDto>>> GetAvailableAppartmentAreasAsync()
        {
            var result = await _requestService.GetAvailableAppartmentAreas();
            return Ok(result);
        }
        [HttpPost]
        [Route("AddRequest")]
        public async Task<ActionResult> AddRequest(AddRequestDto addRequestDto)
        {
            await _requestService.AddRequest(addRequestDto);
            return Ok();
        }
        [HttpGet]
        [Route("GetRequestById")]
        public async Task<ActionResult<RequestReadDto>> GetRequestById(int RequestId)
        {
            var results = await _requestService.GetRequestById(RequestId);
            return Ok(results);
        }

        [HttpPost]
        [Route("CalculateFees")]
        public ActionResult CalculateFees(int RequestId)
        {
            //Calculating Fees
            var fees = _FeesService.calculateFees(RequestId);

            //Storing Fees
            _FeesService.SetFees(RequestId, fees);

            return Ok(fees);
        }

        [HttpPost]
        [Route("AddRequestTrial")]
        public ActionResult AddRequestTrial([FromForm] AddRequestDto addRequestDto, [FromForm] IFormFile file, [FromForm] FileType fileType)
        {

            #region Extention Checking

            var extension = Path.GetExtension(file.FileName);

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

            bool isSizeAllowed = file.Length is > 0 and < 5_000_000; //File Size (Minimum: >0 and Max: 5MB)

            if (!isSizeAllowed)
            {
                return BadRequest("Size is Larger than allowed size");
            }
            #endregion

            #region Storing File
            var generatedFileName = $"{Guid.NewGuid()}{extension}";
            var savedFilePath = Path.Combine(Environment.CurrentDirectory, "UploadedFiles", fileType.ToString(), generatedFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(savedFilePath)!); // Ensure the directory exists

            using (var stream = new FileStream(savedFilePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            #endregion

            #region URL Generating
            var url = $"{Request.Scheme}://{Request.Host}/UploadedFiles/{fileType}/{generatedFileName}";
            #endregion

            var newFile = new UploadFileDTO
            {
                Name = generatedFileName,
                Url = url,
                FileType = fileType
            };


            _requestService.AddRequest(addRequestDto);
            return Ok("Request Added!");
        }

    }
}
