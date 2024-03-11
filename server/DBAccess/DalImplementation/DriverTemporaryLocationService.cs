namespace DBAccess.DalImplementation
{
    public class DriverTemporaryLocationService : IDriverTemporaryLocationService
    {
        TaxiStationContext taxiStationContext;
        public DriverTemporaryLocationService(TaxiStationContext taxiStationContext)
        {
                this.taxiStationContext = taxiStationContext;   
        }
        public Task<bool> CreateAsync(DriverTemporaryLocation entity)
        {
            taxiStationContext.DriverTemporaryLocations.Add(entity);
            taxiStationContext.SaveChanges();
            return Task.FromResult(true);
        }

        public Task<List<DriverTemporaryLocation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DriverTemporaryLocation?> GetAsyncById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string id, DriverTemporaryLocation entity)
        {
            throw new NotImplementedException();
        }
    }
}
