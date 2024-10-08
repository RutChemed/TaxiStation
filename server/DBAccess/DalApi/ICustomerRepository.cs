using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.DalApi
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<OrderingTravel>> GetEligibleDriver(DateTime startTime, DateTime endTime, int minSeats);

    }
}
