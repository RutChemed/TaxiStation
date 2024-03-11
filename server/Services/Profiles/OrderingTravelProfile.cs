using DBAccess.Models;
using Services.DTO;
using System.Net;

namespace Services.Profiles
{
    public class OrderingTravelProfile:Profile
    {
        public OrderingTravelProfile()
        {
            CreateMap<OrderingTravel, OrderingTravelDTO>().ReverseMap();
        }
    }
}
