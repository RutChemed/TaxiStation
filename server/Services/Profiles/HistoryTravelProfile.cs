using DBAccess.Models;
using Services.DTO;
using System.Net;

namespace Services.Profiles
{
    public class HistoryTravelProfile:Profile
    {   
        public HistoryTravelProfile()
        {
            CreateMap<HistoryTravel, HistoryTravelDTO>().ReverseMap();
        }
    }
}
