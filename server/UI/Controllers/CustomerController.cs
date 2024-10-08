using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpPost]
        [Route("book-ride")]
        public IActionResult BookRide(OrderingTravel orderingTravel )
        {

            return Ok("Ride booked successfully.");
        }

        //[HttpPost]
        //[Route("apply-driver")]
        //public IActionResult ApplyDriver(ApplyDriverViewModel model)
        //{
        //    _customerService.ApplyDriver(model);
        //    return Ok("Application submitted successfully.");
        //}
    }
}

