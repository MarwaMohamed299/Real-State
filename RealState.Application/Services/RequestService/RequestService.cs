using RealState.Application.Contracts.Abstractions.Services.CalculateFees;
using RealState.Application.Contracts.Abstractions.Services.RequestService;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using RealState.Application.Contracts.Models;
using RealState.Application.Contracts.Models.Appartments;
using RealState.Application.Contracts.Models.Buildings;
using RealState.Application.Contracts.Models.Cities;
using RealState.Application.Contracts.Models.Governorates;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Services.RequestService
{

    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFeesService _FeesService;
        public RequestService(IUnitOfWork unitOfWork, IFeesService FeesService)
        {
            _unitOfWork = unitOfWork;
            _FeesService = FeesService;
        }

        
        public async Task<IEnumerable<UnitTypeReadDto>> GetUnittypesAsync()
        {
            var units = await _unitOfWork.RequestRepo.GetUnitTypesAsync();
            return units.Select(l => new UnitTypeReadDto
            {
                Id = l.Id,
                Name = l.Name
            });
        }

        public async Task<IEnumerable<AppartmentReadDto>> GetAppartmenttypesAsync()
        {
            var Appartments = await _unitOfWork.RequestRepo.GetAppartmentTypesAsync();
            return Appartments.Select(l => new AppartmentReadDto
            {
                Id = l.Id,
                AppartmentType = l.AppartmentType
            });
        }

        public async Task<IEnumerable<AppartmentAreaDto>> GetAvailableAppartmentAreas()
        {
            var Areas = await _unitOfWork.RequestRepo.GetAvailableAppartmentAreasAsync();
            return Areas.Select(a => new AppartmentAreaDto
            {
                Id = a.Id,
                AvailableAppartmentAreas = a.AvailableAppartmentAreas
            });
        }

        public Task<GetRequestDto> GetRequest(int RequestId)
        {
            throw new NotImplementedException();
        }

        




        //        public Task GetRequest(GetRequestDto readRequestDto)


        //            Domain.Entities.Request newRequest = new Domain.Entities.Request();

        //            newRequest.CreatedAt = DateTime.Now;
        //            newRequest.OwnerAddress = createRequestDto.OwnerAddress;
        //            newRequest.PhoneNumber = createRequestDto.PhoneNumber;
        //            newRequest.UnitArea = createRequestDto.UnitArea;
        //            newRequest.UnitType = createRequestDto.UnitType;
        //            newRequest.FloorCount = createRequestDto.FloorCount;
        //            newRequest.ClientId = createRequestDto.ClientId;
        //            newRequest.Governorate = createRequestDto.Governorate;
        //            newRequest.City = createRequestDto.City;
        //            newRequest.District = createRequestDto.District;
        //            newRequest.Street = createRequestDto.Street;
        //            newRequest.Building = createRequestDto.Building;
        //            newRequest.X = createRequestDto.X;
        //            newRequest.Y = createRequestDto.Y;
        //            newRequest.Fees = float.MaxValue;
        //            newRequest.RequestStatus = createRequestDto.RequestStatus;

        //           await _unitOfWork.RequestRepo.AddAsync(newRequest);
        //           await _unitOfWork.SaveChangesAsync();
        //        }

        //        public async Task<GetRequestDto> GetRequest(int RequestId)
        //        {
        //            var request = await _unitOfWork.RequestRepo.GetByIdAsync(RequestId);
        //            GetRequestDto requestDto = new GetRequestDto();
        //            requestDto.X = request!.X;
        //            requestDto.Y=request.Y;
        //            requestDto.Building = request.Building;
        //            requestDto.City = request.City;
        //            requestDto.Fees = request.Fees; 

        //            return requestDto;
        //        }

        //    }



        public async Task<RequestReadDto> GetRequestById(int RequestId)
        {
            var e = await _unitOfWork.RequestRepo.GetByIdAsync(RequestId);
            var dto = new RequestReadDto
            {
                Id = e!.Id,
                PhoneNumber = e.PhoneNumber,
                AppartmentArea = e.AppartmentArea,
                //CreatedAt = e.CreatedAt,
                Building = e.Building,
                CityId = e.CityId,
                Fees = e.Fees,
                Street = e.Street,
                FloorCount = e.FloorCount,
                District = e.District,
                OwnerAddress = e.OwnerAddress,
                Area = e.Area,
                UnitNumber = e.UnitNumber,
                X = e.X,
                Y = e.Y
            };
            return dto;

        }

        //public async Task AddRequestTrial(AddRequestDto createRequestDto)
        //{
        //    Domain.Entities.Request newRequest = new Domain.Entities.Request();

        //    newRequest.CreatedAt = DateTime.Now;
        //    newRequest.OwnerAddress = createRequestDto.OwnerAddress;
        //    newRequest.PhoneNumber = createRequestDto.PhoneNumber;
        //    newRequest.UnitArea = createRequestDto.UnitArea;
        //    newRequest.UnitTypeId = createRequestDto.UnitTypeId;
        //    newRequest.FloorCount = createRequestDto.FloorCount;
        //    newRequest.ClientId = createRequestDto.ClientId;
        //    newRequest.CityId = createRequestDto.CityId;
        //    newRequest.District = createRequestDto.District;
        //    newRequest.Street = createRequestDto.Street;
        //    newRequest.Building = createRequestDto.Building;
        //    newRequest.X = createRequestDto.X;
        //    newRequest.Y = createRequestDto.Y;
        //    newRequest.AdminId = 32;
        //    newRequest.AuditorId = 5;
        //    newRequest.SurveyerId = 1;




        //    for (int i = 0; i < createRequestDto.uploadFiles.Count; i++)
        //    {
        //        newRequest.UploadFile.Add(new UploadFile()
        //        {
        //            FileType = createRequestDto.uploadFiles[i].FileType,
        //            Name = createRequestDto.uploadFiles[i].Name,
        //            Url = createRequestDto.uploadFiles[i].Url,
        //        });


        //    }



        //    await _unitOfWork.RequestRepo.AddAsync(newRequest);
        //    await _unitOfWork.SaveChangesAsync();

        //    foreach (var file in newRequest.UploadFile)
        //    {
        //        await _unitOfWork.FileRepo.AddAsync(file);
        //        await _unitOfWork.SaveChangesAsync();
        //    }




        //}

        public async Task AddRequest(AddRequestDto createRequestDto)
        {
            Domain.Entities.Request newRequest = new Domain.Entities.Request();

            newRequest.CreatedAt = DateTime.Now;
            newRequest.OwnerAddress = createRequestDto.OwnerAddress;
            newRequest.PhoneNumber = createRequestDto.PhoneNumber;
            newRequest.Area = createRequestDto.Area;
            newRequest.UnitTypeId = createRequestDto.UnitTypeId;
            newRequest.FloorCount = createRequestDto.FloorCount;
            newRequest.ClientId = createRequestDto.ClientId;
            newRequest.CityId = createRequestDto.CityId;
            newRequest.District = createRequestDto.District;
            newRequest.Street = createRequestDto.Street;
            newRequest.Building = createRequestDto.Building;
            newRequest.X = createRequestDto.X;
            newRequest.Y = createRequestDto.Y;
            newRequest.Fees = createRequestDto.Fees;
            newRequest.UnitNumber = createRequestDto.UnitNumber;
            newRequest.AppartmentArea = createRequestDto.AppartmentArea;

            await _unitOfWork.RequestRepo.AddAsync(newRequest);
            await _unitOfWork.SaveChangesAsync();


        }
    }
}