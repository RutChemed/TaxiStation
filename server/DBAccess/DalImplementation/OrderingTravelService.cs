using DBAccess.Models;

namespace DBAccess.DalImplementation
{
    public class OrderingTravelService:IOrderingTravelService
    {
        private readonly TaxiStationContext taxiStationContext;
        public OrderingTravelService(TaxiStationContext taxiStationContext)
        {
            this.taxiStationContext = taxiStationContext;
        }
        public async Task<OrderingTravel> CreateAsync(OrderingTravel entity)
        {
            taxiStationContext.OrderingTravels.Add(entity);
            await taxiStationContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<OrderingTravel>> GetAllAsync()
        {
            return await taxiStationContext.OrderingTravels.ToListAsync();
        }

        public async Task<OrderingTravel?> GetAsyncById(int id)
        {
            return await taxiStationContext.OrderingTravels
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<OrderingTravel> RemoveAsync(int entityId)
        {
            var result = await taxiStationContext.OrderingTravels
            .FirstOrDefaultAsync(e => e.Id == entityId);
            if (result != null)
            {
                taxiStationContext.OrderingTravels.Remove(result);
                await taxiStationContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<bool> UpdateAsync(OrderingTravel entity)
        {
            var result = await taxiStationContext.OrderingTravels
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (result != null)
            {
                result.StartTime = entity.StartTime;
                result.EndTime = entity.EndTime;
                result.ExitLatitudes = entity.ExitLatitudes;
                result.TargetLatitudes = entity.TargetLatitudes;
                result.TargetLongitudes = entity.TargetLongitudes;
                result.PassengersNum = entity.PassengersNum;
                result.Driver = entity.Driver;
                result.ClientPhone = entity.ClientPhone;
                result.DriverNavigation = entity.DriverNavigation;
                await taxiStationContext.SaveChangesAsync();
                return true;
            }

            return true;
        }
    }
}
