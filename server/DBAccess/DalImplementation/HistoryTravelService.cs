namespace DBAccess.DalImplementation
{
    public class HistoryTravelService : IHistoryTravelService
    {
        private readonly TaxiStationContext taxiStationContext;
        public HistoryTravelService(TaxiStationContext taxiStationContext)
        {
            this.taxiStationContext = taxiStationContext;
        }
        public async Task<bool> CreateAsync(HistoryTravel entity)
        {

            var result = await taxiStationContext.HistoryTravels.AddAsync(entity);
            await taxiStationContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<HistoryTravel>> GetAllAsync()
        {
            return await taxiStationContext.HistoryTravels.ToListAsync();
        }

        public async Task<HistoryTravel?> GetAsyncById(int id)
        {
            return await taxiStationContext.HistoryTravels
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var result = await taxiStationContext.HistoryTravels
            .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                taxiStationContext.HistoryTravels.Remove(result);
                await taxiStationContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(HistoryTravel entity)
        {
            var result = await taxiStationContext.HistoryTravels
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (result != null)
            {
                result.StartTime = entity.StartTime;
                result.EndTime = entity.EndTime;
                result.ExitLatitudes = entity.ExitLatitudes;
                result.ExitLongitudes = entity.ExitLongitudes;
                result.TargetLatitudes = entity.TargetLatitudes;
                result.TargetLongitudes = entity.TargetLongitudes;
                result.PassengersNum = entity.PassengersNum;
                result.Driver = entity.Driver;
                result.ClientPhone = entity.ClientPhone;
                await taxiStationContext.SaveChangesAsync();
                return true;
            }

            return true;
        }
    }
}
