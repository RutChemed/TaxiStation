using DBAccess.Models;
using Services.DTO;
using System.Net;

namespace Services.Profiles
{
    public class DriverTemporaryLocationProfile:Profile
    {
        public DriverTemporaryLocationProfile()
        {
            CreateMap<DriverTemporaryLocation, DriverTemporaryLocationDTO>().ReverseMap();
        }
    }
}
