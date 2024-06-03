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
        public async Task<OrderingTravelDTO> CreateAsync(OrderingTravelDTO entity)
        {
            var dalEntity = _mapper.Map<OrderingTravel>(entity);
            var createdEntity = await _orderingTravelService.CreateAsync(dalEntity);
            return _mapper.Map<OrderingTravelDTO>(createdEntity);
        }

        public async Task<bool> UpdateAsync(OrderingTravelDTO entity)
        {
            OrderingTravel dalEntity = _mapper.Map<OrderingTravel>(entity);
            return await _orderingTravelService.UpdateAsync(dalEntity);
        }

        public async Task<OrderingTravelDTO> RemoveAsync(int id)
        {
            var deletedEntity = await _orderingTravelService.RemoveAsync(id);
            if (deletedEntity != null)
            {
                return _mapper.Map<OrderingTravelDTO>(deletedEntity);
            }

            return null;
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
