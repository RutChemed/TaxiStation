using DBAccess.Models;
using Services.DTO;
using System.Net;

namespace Services.Profiles
{
    public class PhysicalEmployeeDetailProfile:Profile
    {
        public PhysicalEmployeeDetailProfile()
        {
            CreateMap<PhysicalEmployeeDetail, PhysicalEmployeeDetailDTO>().ReverseMap();
        }
    }
}
