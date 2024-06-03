namespace Services.ServicesImplementation
{
    public class TechnicalEmployeeDetailBlService:ITechnicalEmployeeDetailBlService
    {
        private readonly IMapper _mapper;
        private readonly ITechnicalEmployeeDetailService _technicalEmployeeDetailService;
        public TechnicalEmployeeDetailBlService(IMapper mapper, ITechnicalEmployeeDetailService technicalEmployeeDetailService)
        {
            _mapper = mapper;
            _technicalEmployeeDetailService = technicalEmployeeDetailService;

        }
        public async Task<TechnicalEmployeeDetailDTO> CreateAsync(TechnicalEmployeeDetailDTO entity)
        {
            var dalEntity = _mapper.Map<TechnicalEmployeeDetail>(entity);
            var createdEntity = await _technicalEmployeeDetailService.CreateAsync(dalEntity);
            return _mapper.Map<TechnicalEmployeeDetailDTO>(createdEntity);
        }
        public async Task<bool> UpdateAsync(TechnicalEmployeeDetailDTO entity)
        {
            TechnicalEmployeeDetail dalEntity = _mapper.Map<TechnicalEmployeeDetail>(entity);
            return await _technicalEmployeeDetailService.UpdateAsync(dalEntity);
        }
        public async Task<TechnicalEmployeeDetailDTO> RemoveAsync(int id)
        {
            var deletedEntity = await _technicalEmployeeDetailService.RemoveAsync(id);
            if (deletedEntity != null)
            {
                return _mapper.Map<TechnicalEmployeeDetailDTO>(deletedEntity);
            }

            return null;
        }

        public async Task<IEnumerable<TechnicalEmployeeDetailDTO>> GetAllAsync()
        {
            IEnumerable<TechnicalEmployeeDetail> TechnicalEmployeeDetails = await _technicalEmployeeDetailService.GetAllAsync();
            return _mapper.Map<IEnumerable<TechnicalEmployeeDetailDTO>>(TechnicalEmployeeDetails);
        }

        public async Task<TechnicalEmployeeDetailDTO?> GetAsyncById(int id)
        {
            TechnicalEmployeeDetail? TechnicalEmployeeDetail = await _technicalEmployeeDetailService.GetAsyncById(id);
            return _mapper.Map<TechnicalEmployeeDetailDTO>(TechnicalEmployeeDetail);
        }
    }
}

