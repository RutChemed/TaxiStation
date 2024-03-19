namespace Services.Profiles
{
    public class TechnicalEmployeeDetailProfile:Profile
    {
        public TechnicalEmployeeDetailProfile()
        {
            CreateMap<TechnicalEmployeeDetail, TechnicalEmployeeDetailDTO>().ReverseMap();
        }
    }
}
