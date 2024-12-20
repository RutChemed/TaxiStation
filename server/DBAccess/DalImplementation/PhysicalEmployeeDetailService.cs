﻿namespace DBAccess.DalImplementation
{
    public class PhysicalEmployeeDetailService:IPhysicalEmployeeDetailService
    {
        private readonly TaxiStationContext taxiStationContext;
        public PhysicalEmployeeDetailService(TaxiStationContext taxiStationContext)
        {
            this.taxiStationContext = taxiStationContext;
        }
        public async Task<PhysicalEmployeeDetail> CreateAsync(PhysicalEmployeeDetail entity)
        {
            taxiStationContext.PhysicalEmployeeDetails.Add(entity);
            await taxiStationContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<PhysicalEmployeeDetail>> GetAllAsync()
        {
            return await taxiStationContext.PhysicalEmployeeDetails.ToListAsync();
        }

        public async Task<PhysicalEmployeeDetail?> GetAsyncById(int id)
        {
            return await taxiStationContext.PhysicalEmployeeDetails
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<PhysicalEmployeeDetail?> GetAsyncByEmployee(int id)
        {
            return await taxiStationContext.PhysicalEmployeeDetails
                .FirstOrDefaultAsync(e => e.Employee == id);
        }

        public async Task<PhysicalEmployeeDetail> RemoveAsync(int entityId)
        {
            var result = await taxiStationContext.PhysicalEmployeeDetails
            .FirstOrDefaultAsync(e => e.Id == entityId);
            if (result != null)
            {
                taxiStationContext.PhysicalEmployeeDetails.Remove(result);
                await taxiStationContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<bool> UpdateAsync(PhysicalEmployeeDetail entity)
        {
            // בדיקה אם המזהה של TechnicalEmployee קיים
            var technicalEmployeeExists = await taxiStationContext.TechnicalEmployeeDetails
                .AnyAsync(e => e.Id == entity.Employee);

            if (!technicalEmployeeExists)
            {
                // אם המזהה לא קיים, נצא מהפונקציה וניתן חיווי על כך
                return false;
            }

            // שליפת הנתונים של PhysicalEmployeeDetails לעדכון
            var result = await taxiStationContext.PhysicalEmployeeDetails
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (result != null)
            {
                // עדכון השדות ברשומה הקיימת
                result.Employee = entity.Employee;
                result.Available = entity.Available;
                result.NumPlaces = entity.NumPlaces;
                result.Latitudes = entity.Latitudes;
                result.Longitudes = entity.Longitudes;
                result.EmployeeNavigation = entity.EmployeeNavigation;

                await taxiStationContext.SaveChangesAsync(); // שמירת השינויים
                return true;
            }

            return false; // רשומת PhysicalEmployeeDetails לא קיימת
        }

        //public async Task<bool> UpdateAsync(PhysicalEmployeeDetail entity)
        //{
        //    var result = await taxiStationContext.PhysicalEmployeeDetails
        //        .FirstOrDefaultAsync(e => e.Id == entity.Id);

        //    if (result != null)
        //    {
        //        result.Employee = entity.Employee;
        //        result.Available = entity.Available;
        //        result.NumPlaces = entity.NumPlaces;
        //        result.Latitudes = entity.Latitudes;
        //        result.Longitudes = entity.Longitudes;
        //        result.EmployeeNavigation = entity.EmployeeNavigation;
        //        await taxiStationContext.SaveChangesAsync();
        //        return true;
        //    }

        //    return true;
        //}
    }
}