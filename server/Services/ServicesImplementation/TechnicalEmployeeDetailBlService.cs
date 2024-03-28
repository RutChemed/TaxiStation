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
        public async Task<bool> CreateAsync(TechnicalEmployeeDetailDTO entity)
        {
            TechnicalEmployeeDetail dalEntity = _mapper.Map<TechnicalEmployeeDetail>(entity);
            return await _technicalEmployeeDetailService.CreateAsync(dalEntity);
        }

        public async Task<bool> UpdateAsync(TechnicalEmployeeDetailDTO entity)
        {
            TechnicalEmployeeDetail dalEntity = _mapper.Map<TechnicalEmployeeDetail>(entity);
            return await _technicalEmployeeDetailService.UpdateAsync(dalEntity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _technicalEmployeeDetailService.RemoveAsync(id);
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

