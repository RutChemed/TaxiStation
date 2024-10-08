using DBAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.DalImplementation
{
    public class DriverRepository:IDriverRepository
    {
        private readonly TaxiStationContext _taxiStationContext;

        public DriverRepository(TaxiStationContext taxiStationContext)
            {
            _taxiStationContext = taxiStationContext;
            }


        }
}
