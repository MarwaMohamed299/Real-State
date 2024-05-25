using RealState.Application.Contracts.Models;
using RealState.Application.Contracts.Models.Appartments;
using RealState.Application.Contracts.Models.Buildings;
using RealState.Application.Contracts.Models.Cities;
using RealState.Application.Contracts.Models.Governorates;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Services.RequestService
{
    public interface IRequestService
    {
        Task AddRequest(AddRequestDto createRequestDto);
        //Task AddRequestTrial(AddRequestDto createRequestDto);
        
        Task<IEnumerable<UnitTypeReadDto>> GetUnittypesAsync();
        Task<IEnumerable<AppartmentReadDto>> GetAppartmenttypesAsync();
        Task<IEnumerable<AppartmentAreaDto>> GetAvailableAppartmentAreas();
        Task<RequestReadDto> GetRequestById(int RequestId);
    }
}
