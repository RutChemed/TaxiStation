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
        public async Task<PhysicalEmployeeDetailDTO> CreateAsync(PhysicalEmployeeDetailDTO entity)
        {
            var dalEntity = _mapper.Map<PhysicalEmployeeDetail>(entity);
            var createdEntity = await _physicalEmployeeDetailService.CreateAsync(dalEntity);
            return _mapper.Map<PhysicalEmployeeDetailDTO>(createdEntity);
        }

        public async Task<bool> UpdateAsync(PhysicalEmployeeDetailDTO entity)
        {
            PhysicalEmployeeDetail dalEntity = _mapper.Map<PhysicalEmployeeDetail>(entity);
            return await _physicalEmployeeDetailService.UpdateAsync(dalEntity);
        }

        public async Task<PhysicalEmployeeDetailDTO> RemoveAsync(int id)
        {
            var deletedEntity = await _physicalEmployeeDetailService.RemoveAsync(id);
            if (deletedEntity != null)
            {
                return _mapper.Map<PhysicalEmployeeDetailDTO>(deletedEntity);
            }

            return null;
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

        public async Task<PhysicalEmployeeDetailDTO?> GetAsyncByEmployee(int id)
        {
            PhysicalEmployeeDetail? PhysicalEmployeeDetail = await _physicalEmployeeDetailService.GetAsyncByEmployee(id);
            return _mapper.Map<PhysicalEmployeeDetailDTO>(PhysicalEmployeeDetail);
        }
    }
}
