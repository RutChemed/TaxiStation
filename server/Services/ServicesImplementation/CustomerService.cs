using DBAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesImplementation
{
    public class CustomerService:ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;

        }
        //public async Task<bool> ApplyDriver(OrderingTravelDTO orderingTravel)
        //{
        //    IEnumerable<OrderingTravel> result = await _customerRepository.GetEligibleDriver(DateTime.Parse("2022-04-22 20:34:23"),DateTime.Parse("2022-04-22 18:34:23"), 7);
        //    List<OrderingTravel> list = result.ToList();


        //}

    }
}
