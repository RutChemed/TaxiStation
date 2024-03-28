namespace Services.ServicesImplementation
{
    public class OrderingTravelBlService:IOrderingTravelBlService
    {
        private readonly IMapper _mapper;
        private readonly IOrderingTravelService _orderingTravelService;
        public OrderingTravelBlService(IMapper mapper,IOrderingTravelService orderingTravelService)
        {
            _mapper = mapper;
            _orderingTravelService = orderingTravelService;

        }
        public async Task<bool> CreateAsync(OrderingTravelDTO entity)
        {
            OrderingTravel dalEntity = _mapper.Map<OrderingTravel>(entity);
            return await _orderingTravelService.CreateAsync(dalEntity);
        }

        public async Task<bool> UpdateAsync(OrderingTravelDTO entity)
        {
            OrderingTravel dalEntity = _mapper.Map<OrderingTravel>(entity);
            return await _orderingTravelService.UpdateAsync(dalEntity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _orderingTravelService.RemoveAsync(id);
        }

        public async Task<IEnumerable<OrderingTravelDTO>> GetAllAsync()
        {
            IEnumerable<OrderingTravel> OrderingTravels = await _orderingTravelService.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderingTravelDTO>>(OrderingTravels);
        }

        public async Task<OrderingTravelDTO?> GetAsyncById(int id)
        {
            OrderingTravel? OrderingTravel = await _orderingTravelService.GetAsyncById(id);
            return _mapper.Map<OrderingTravelDTO>(OrderingTravel);
        }
     
    }
}
