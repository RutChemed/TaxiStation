using DBAccess.Models;
using Services.DTO;

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
        public async Task<DriverTemporaryLocationDTO> CreateAsync(DriverTemporaryLocationDTO entity)
        {
            var dalEntity = _mapper.Map<DriverTemporaryLocation>(entity);
            var createdEntity = await _driverTemporaryLocationService.CreateAsync(dalEntity);
            return _mapper.Map<DriverTemporaryLocationDTO>(createdEntity);
        }

        public async Task<bool> UpdateAsync(DriverTemporaryLocationDTO entity)
        {
            DriverTemporaryLocation dalEntity = _mapper.Map<DriverTemporaryLocation>(entity);
            return await _driverTemporaryLocationService.UpdateAsync(dalEntity);
        }

        public async Task<DriverTemporaryLocationDTO> RemoveAsync(int id)
        {
            var deletedEntity = await _driverTemporaryLocationService.RemoveAsync(id);
            if (deletedEntity != null)
            {
                return _mapper.Map<DriverTemporaryLocationDTO>(deletedEntity);
            }

            return null;
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

