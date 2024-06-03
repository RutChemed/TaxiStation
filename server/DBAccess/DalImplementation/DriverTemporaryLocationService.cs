using Microsoft.EntityFrameworkCore;
using System;

namespace DBAccess.DalImplementation
{
    public class DriverTemporaryLocationService : IDriverTemporaryLocationService
    {
        private readonly TaxiStationContext taxiStationContext;
        public DriverTemporaryLocationService(TaxiStationContext taxiStationContext)
        {
                this.taxiStationContext = taxiStationContext;
        }
        public async Task<DriverTemporaryLocation> CreateAsync(DriverTemporaryLocation entity)
        {
            taxiStationContext.DriverTemporaryLocations.Add(entity);
            await taxiStationContext.SaveChangesAsync();
            return entity;
        }
       
        public async Task<IEnumerable<DriverTemporaryLocation>> GetAllAsync()
        {
            return await taxiStationContext.DriverTemporaryLocations.ToListAsync();
        }

        public async Task<DriverTemporaryLocation?> GetAsyncById(int id)
        {
            return await taxiStationContext.DriverTemporaryLocations
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<DriverTemporaryLocation> RemoveAsync(int entityId)
        {
            var result = await taxiStationContext.DriverTemporaryLocations
                .FirstOrDefaultAsync(e => e.Id == entityId);
            if (result != null)
            {
                taxiStationContext.DriverTemporaryLocations.Remove(result);
                await taxiStationContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

    public async Task<bool> UpdateAsync(DriverTemporaryLocation entity)
        {
            var result = await taxiStationContext.DriverTemporaryLocations
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (result != null)
            {
                result.Driver = entity.Driver;
                result.StartTime = entity.StartTime;
                result.EndTime = entity.EndTime;
                result.Latitudes = entity.Latitudes;
                result.Longitudes = entity.Longitudes;
                result.DriverNavigation = entity.DriverNavigation;
                await taxiStationContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}