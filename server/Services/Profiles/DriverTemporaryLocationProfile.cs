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
