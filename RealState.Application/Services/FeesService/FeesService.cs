using RealState.Application.Contracts.Abstractions.Services.CalculateFees;
using RealState.Application.Contracts.Abstractions.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Services.CalculateFeesService
{
    public class FeesService : IFeesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public float calculateFees(int RequestId)
        {
            Random random = new Random();
            float randomFloat = GetRandomFloat(random, 250f, 1500f);
            return randomFloat;
        }


        public static float GetRandomFloat(Random random, float minValue, float maxValue)
        {
            double range = maxValue - minValue;
            double sample = random.NextDouble(); // Returns a double between 0.0 and 1.0
            double scaled = (sample * range) + minValue;
            return (float)scaled;
        }

        public async Task SetFees(int RequestId, float fees)
        {
            var request = await _unitOfWork.RequestRepo.GetByIdAsync(RequestId);
            request!.Fees= fees;
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
