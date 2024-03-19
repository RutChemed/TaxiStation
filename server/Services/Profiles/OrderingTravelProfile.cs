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
