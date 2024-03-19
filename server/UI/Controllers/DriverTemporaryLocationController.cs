using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.ServicesApi;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverTemporaryLocationController : ControllerBase
    {
        private readonly IDriverTemporaryLocationBlService driverTemporaryLocationBlService;

        public DriverTemporaryLocationController(IDriverTemporaryLocationBlService driverTemporaryLocationBlService)
        {
            this.driverTemporaryLocationBlService = driverTemporaryLocationBlService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await driverTemporaryLocationBlService.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DriverTemporaryLocationDTO>> GetByIdAsync(int id)
        {
            try
            {
                var result = await driverTemporaryLocationBlService.GetAsyncById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        //[HttpPost]
        //public async Task<ActionResult<DriverTemporaryLocationDTO>> CreateEAsync(DriverTemporaryLocationDTO entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            return BadRequest();
        //        }

        //        var tempEntity = driverTemporaryLocationBlService.GetAsyncById(entity.Id);

        //        if (tempEntity != null)
        //        {
        //            ModelState.AddModelError("Id", "Employee Id already in use");
        //            return BadRequest(ModelState);
        //        }

        //        var createdEntity = await driverTemporaryLocationBlService.CreateAsync(entity);

        //        return CreatedAtAction(nameof(GetByIdAsync), new { id = entity.Id },
        //            createdEntity);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<DriverTemporaryLocationDTO>> UpdateEmployee(int id, DriverTemporaryLocationDTO entity)
        //{
        //    try
        //    {
        //        if (id != entity.Id)
        //        {
        //            return BadRequest("Employee ID mismatch");
        //        }

        //        var entityToUpdate = await driverTemporaryLocationBlService.GetAsyncById(id);

        //        if (entityToUpdate == null)
        //        {
        //            return NotFound($"Employee with Id = {id} not found");
        //        }

        //        await driverTemporaryLocationBlService.UpdateAsync(entity);
        //        return
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error updating data");
        //    }
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<DriverTemporaryLocationDTO>> DeleteEmployee(int id)
        //{
        //    try
        //    {
        //        var employeeToDelete = await driverTemporaryLocationBlService.GetAsyncById(id);

        //        if (employeeToDelete == null)
        //        {
        //            return NotFound($"Employee with Id = {id} not found");
        //        }

        //        await driverTemporaryLocationBlService.RemoveAsync(id);
        //        return
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error deleting data");
        //    }
        //}
    }
}
