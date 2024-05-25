using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Contracts.Abstractions.Services.CalculateFees
{
    public interface IFeesService
    {
         float calculateFees(int RequestId);
         Task SetFees(int RequestId, float fees);
    }
}
