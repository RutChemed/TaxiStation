using DBAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess.DalImplementation
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly TaxiStationContext taxiStationContext;
        public CustomerRepository(TaxiStationContext taxiStationContext)
        {
            this.taxiStationContext = taxiStationContext;
        }
        //DateTime startTime = DateTime.Parse("2022-04-22 18:34:23");
        //DateTime endTime = DateTime.Parse("2022-04-22 20:34:23")
        //public async Task<IEnumerable<OrderingTravel>> GetEligibleDriver(DateTime startTime, DateTime endTime)
        //{
        /// <summary>
        /// Retrieves a sorted list of drivers eligible for a new trip based on availability.
        /// Drivers are filtered to include those who have no conflicting trips during the specified time
        /// and those who currently have no booked trips.
        /// </summary>
        /// <param name="startTime">Start date and time of the new trip.</param>
        /// <param name="endTime">End date and time of the new trip.</param>
        /// <param name="minSeats">Minimum seats thet requaired for the travel</param>
        /// <returns>An IEnumerable of OrderingTravel objects representing eligible drivers.</returns>
        public async Task<IEnumerable<OrderingTravel>> GetEligibleDriver(DateTime startTime, DateTime endTime,int minSeats)
            {
                var conflictingDrivers = taxiStationContext.OrderingTravels
                    .Where(ot => ot.EndTime > startTime && ot.StartTime < endTime)
                    .Select(ot => ot.Driver)
                    .Distinct()
                    .ToList();

                var trips = taxiStationContext.OrderingTravels
                    .Join(taxiStationContext.PhysicalEmployeeDetails,
                          ot => ot.Driver,
                          ped => ped.Id,
                          (ot, ped) => new { ot, ped })
                    .Where(joined => !conflictingDrivers.Contains(joined.ot.Driver) && joined.ped.NumPlaces >= minSeats)
                    .Select(joined => joined.ot)
                    .ToList();

                var driversWithoutTrips = taxiStationContext.PhysicalEmployeeDetails
                    .GroupJoin(taxiStationContext.OrderingTravels,
                               ped => ped.Id,
                               ot => ot.Driver,
                               (ped, ot) => new { ped, ot })
                    .SelectMany(joined => joined.ot.DefaultIfEmpty(),
                                (joined, ot) => new { joined.ped, ot })
                    .Where(result => result.ot == null)
                    .Select(result => new OrderingTravel
                    {
                        Driver = result.ped.Id,
                        // Other properties can be set as needed
                    })
                    .ToList();

                return trips.Union(driversWithoutTrips).OrderBy(t => t.Driver);
            }
    }
}