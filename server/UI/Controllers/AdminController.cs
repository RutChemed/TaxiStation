using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        //[HttpPost]
        //[Route("add-driver")]
        //public IActionResult AddDriver(AddDriverViewModel model)
        //{
        //    _adminService.AddDriver(model);
        //    return Ok("Driver added successfully.");
        //}

        //[HttpGet]
        //[Route("drivers")]
        //public IActionResult GetDrivers()
        //{
        //    var drivers = _adminService.GetDrivers();
        //    return Ok(drivers);
        //}

        //[HttpPut]
        //[Route("fire-driver")]
        //public IActionResult FireDriver(FireDriverViewModel model)
        //{
        //    _adminService.FireDriver(model);
        //    return Ok("Driver fired successfully.");
        //}

        //[HttpPost]
        //[Route("send-message")]
        //public IActionResult SendMessageToDrivers(string message)
        //{
        //    _adminService.SendMessageToDrivers(message);
        //    return Ok("Message sent successfully.");
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
