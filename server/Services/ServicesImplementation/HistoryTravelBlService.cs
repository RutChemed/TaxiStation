namespace Services.ServicesImplementation
{
    public class HistoryTravelBlService:IHistoryTravelBlService
    {
        private readonly IMapper _mapper;
        private readonly IHistoryTravelService _historyTravelService;
        public HistoryTravelBlService(IMapper mapper,IHistoryTravelService historyTravelService)
        {
            _mapper = mapper;
            _historyTravelService = historyTravelService;

        }
        public async Task<bool> CreateAsync(HistoryTravelDTO entity)
        {
            HistoryTravel dalEntity = _mapper.Map<HistoryTravel>(entity);
            return await _historyTravelService.CreateAsync(dalEntity);
        }

        public async Task<bool> UpdateAsync(HistoryTravelDTO entity)
        {
            HistoryTravel dalEntity = _mapper.Map<HistoryTravel>(entity);
            return await _historyTravelService.UpdateAsync(dalEntity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _historyTravelService.RemoveAsync(id);
        }

        public async Task<IEnumerable<HistoryTravelDTO>> GetAllAsync()
        {
            IEnumerable<HistoryTravel> HistoryTravels = await _historyTravelService.GetAllAsync();
            return _mapper.Map<IEnumerable<HistoryTravelDTO>>(HistoryTravels);
        }

        public async Task<HistoryTravelDTO?> GetAsyncById(int id)
        {
            HistoryTravel? HistoryTravel = await _historyTravelService.GetAsyncById(id);
            return _mapper.Map<HistoryTravelDTO>(HistoryTravel);
        }
    }
}
