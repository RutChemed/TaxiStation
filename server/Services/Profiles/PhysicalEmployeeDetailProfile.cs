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
