
namespace Services.ServicesImplementation
{
    public class DriverTemporaryLocationBlService : IDriverTemporaryLocationBlService
    {
        private readonly IMapper _mapper;
        private readonly IDriverTemporaryLocationService _driverTemporaryLocationService;
        public DriverTemporaryLocationBlService(IMapper mapper, IDriverTemporaryLocationService driverTemporaryLocationService)
        {
            _mapper = mapper;
            _driverTemporaryLocationService = driverTemporaryLocationService;
        }
        public async Task<bool> CreateAsync(DriverTemporaryLocationDTO entity)
        {
            DriverTemporaryLocation dalEntity = _mapper.Map<DriverTemporaryLocation>(entity);
            return await _driverTemporaryLocationService.CreateAsync(dalEntity);
        }

        public async Task<bool> UpdateAsync(DriverTemporaryLocationDTO entity)
        {
            DriverTemporaryLocation dalEntity = _mapper.Map<DriverTemporaryLocation>(entity);
            return await _driverTemporaryLocationService.UpdateAsync(dalEntity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _driverTemporaryLocationService.RemoveAsync(id);
        }

        public async Task<IEnumerable<DriverTemporaryLocationDTO>> GetAllAsync()
        {
            IEnumerable<DriverTemporaryLocation> driverTemporaryLocations = await _driverTemporaryLocationService.GetAllAsync();
            return _mapper.Map<IEnumerable<DriverTemporaryLocationDTO>>(driverTemporaryLocations);
        }

        public async Task<DriverTemporaryLocationDTO?> GetAsyncById(int id)
        {
            DriverTemporaryLocation? driverTemporaryLocation = await _driverTemporaryLocationService.GetAsyncById(id);
            return _mapper.Map<DriverTemporaryLocationDTO>(driverTemporaryLocation);
        }

    }
}

