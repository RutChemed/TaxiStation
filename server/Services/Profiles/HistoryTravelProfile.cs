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
