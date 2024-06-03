namespace DBAccess.DalImplementation
{
    public class TechnicalEmployeeDetailService:ITechnicalEmployeeDetailService
    {
        private readonly TaxiStationContext taxiStationContext;
        public TechnicalEmployeeDetailService(TaxiStationContext taxiStationContext)
        {
            this.taxiStationContext = taxiStationContext;
        }

        public async Task<TechnicalEmployeeDetail> CreateAsync(TechnicalEmployeeDetail entity)
        {
            taxiStationContext.TechnicalEmployeeDetails.Add(entity);
            await taxiStationContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<TechnicalEmployeeDetail>> GetAllAsync()
        {
            return await taxiStationContext.TechnicalEmployeeDetails.ToListAsync();
        }

        public async Task<TechnicalEmployeeDetail?> GetAsyncById(int id)
        {
            return await taxiStationContext.TechnicalEmployeeDetails
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TechnicalEmployeeDetail> RemoveAsync(int entityId)
        {
            var result = await taxiStationContext.TechnicalEmployeeDetails
            .FirstOrDefaultAsync(e => e.Id == entityId);
            if (result != null)
            {
                taxiStationContext.TechnicalEmployeeDetails.Remove(result);
                await taxiStationContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<bool> UpdateAsync(TechnicalEmployeeDetail entity)
        {
            var result = await taxiStationContext.TechnicalEmployeeDetails
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.Phone = entity.Phone;
                result.Email = entity.Email;
                result.Password = entity.Password;
                result.DepartureDate = entity.DepartureDate;
                result.Role = entity.Role;
                result.AddressLatitudes = entity.AddressLatitudes;
                result.AddressLongitudes = entity.AddressLongitudes;
                //result.PhysicalEmployeeDetails = entity.PhysicalEmployeeDetails; -without set function
                await taxiStationContext.SaveChangesAsync();
                return true;
            }

            return true;
        }
    }
}
