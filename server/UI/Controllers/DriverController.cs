using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
      
            // שליפת המשתמש לפי האימייל


        //[HttpGet]
        //[Route("work-schedule")]
        //public IActionResult GetWorkSchedule(int driverId)
        //{
        //    var schedule = _driverService.GetWorkSchedule(driverId);
        //    return Ok(schedule);
        //}

        //[HttpPut]
        //[Route("transfer-ride")]
        //public IActionResult TransferRide(int rideId, int newDriverId)
        //{
        //    _driverService.TransferRide(rideId, newDriverId);
        //    return Ok("Ride transferred successfully.");
        //}

        //[HttpPut]
        //[Route("update-status")]
        //public IActionResult UpdateStatus(UpdateStatusViewModel model)
        //{
        //    _driverService.UpdateStatus(model);
        //    return Ok("Status updated successfully.");
        //}

        //[HttpPut]
        //[Route("update-status")]
        //public IActionResult UpdatePersonalDetails(UpdateStatusViewModel model)
        //{
        //    _driverService.UpdateStatus(model);
        //    return Ok("Status updated successfully.");
        //}
    }
}
