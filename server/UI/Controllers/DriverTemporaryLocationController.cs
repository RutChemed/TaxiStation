using Services.DTO;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverTemporaryLocationController : ControllerBase
    {
        private readonly IDriverTemporaryLocationBlService driverTemporaryLocationBlService;

        public DriverTemporaryLocationController(IDriverTemporaryLocationBlService driverTemporaryLocationBlService)
        {
            this.driverTemporaryLocationBlService = driverTemporaryLocationBlService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverTemporaryLocationDTO>>> GetAsync()
        {
            try
            {
                return Ok(await driverTemporaryLocationBlService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
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
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<DriverTemporaryLocationDTO>> CreateEmployee(DriverTemporaryLocationDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }

                var createdEntity = await driverTemporaryLocationBlService.CreateAsync(entity);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   e.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DriverTemporaryLocationDTO>> DeleteAsync(int id)

        {
            try
            {
                var entityToDelete = await driverTemporaryLocationBlService.GetAsyncById(id);

                if (entityToDelete == null)
                {
                    return NotFound($"entity with Id = {id} not found");
                }

                return await driverTemporaryLocationBlService.RemoveAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<bool>> PutAsync(int id, DriverTemporaryLocationDTO entity)
        //{
        //    try
        //    {
        //        if (id != entity.Id)
        //        {
        //            return BadRequest("entity ID mismatch");
        //        }

        //        var entityToUpdate = await driverTemporaryLocationBlService.GetAsyncById(id);

        //        if (entityToUpdate == null)
        //        {
        //            return NotFound($"entity with Id = {id} not found");
        //        }

        //        return await driverTemporaryLocationBlService.UpdateAsync(entity);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error updating data");
        //    }
        //}
    }
}
