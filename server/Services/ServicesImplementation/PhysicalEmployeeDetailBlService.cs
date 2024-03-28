namespace Services.ServicesImplementation
{
    public class PhysicalEmployeeDetailBlService:IPhysicalEmployeeDetailBlService
    {
        private readonly IMapper _mapper;
        private readonly IPhysicalEmployeeDetailService _physicalEmployeeDetailService;
        public PhysicalEmployeeDetailBlService(IMapper mapper,IPhysicalEmployeeDetailService physicalEmployeeDetailService)
        {
            _mapper = mapper;
            _physicalEmployeeDetailService = physicalEmployeeDetailService;
        }
        public async Task<bool> CreateAsync(PhysicalEmployeeDetailDTO entity)
        {
            PhysicalEmployeeDetail dalEntity = _mapper.Map<PhysicalEmployeeDetail>(entity);
            return await _physicalEmployeeDetailService.CreateAsync(dalEntity);
        }

        public async Task<bool> UpdateAsync(PhysicalEmployeeDetailDTO entity)
        {
            PhysicalEmployeeDetail dalEntity = _mapper.Map<PhysicalEmployeeDetail>(entity);
            return await _physicalEmployeeDetailService.UpdateAsync(dalEntity);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            return await _physicalEmployeeDetailService.RemoveAsync(id);
        }

        public async Task<IEnumerable<PhysicalEmployeeDetailDTO>> GetAllAsync()
        {
            IEnumerable<PhysicalEmployeeDetail> PhysicalEmployeeDetails = await _physicalEmployeeDetailService.GetAllAsync();
            return _mapper.Map<IEnumerable<PhysicalEmployeeDetailDTO>>(PhysicalEmployeeDetails);
        }

        public async Task<PhysicalEmployeeDetailDTO?> GetAsyncById(int id)
        {
            PhysicalEmployeeDetail? PhysicalEmployeeDetail = await _physicalEmployeeDetailService.GetAsyncById(id);
            return _mapper.Map<PhysicalEmployeeDetailDTO>(PhysicalEmployeeDetail);
        }
    }
}
