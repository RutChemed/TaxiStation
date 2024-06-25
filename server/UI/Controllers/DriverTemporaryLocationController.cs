using Microsoft.AspNetCore.Http.HttpResults;
using Services.DTO;
using UI.ApiController;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverTemporaryLocationController : ControllerBase
    {
        private readonly IDriverTemporaryLocationBlService driverTemporaryLocationBlService;
        private readonly ILogger<DriverTemporaryLocationController> logger;
        private readonly IPhysicalEmployeeDetailController physicalEmployeeDetailController;

        public DriverTemporaryLocationController(IDriverTemporaryLocationBlService driverTemporaryLocationBlService, ILogger<DriverTemporaryLocationController> logger,IPhysicalEmployeeDetailController physicalEmployeeDetailController)
        {
            this.driverTemporaryLocationBlService = driverTemporaryLocationBlService;
            this.logger = logger;
            this.physicalEmployeeDetailController = physicalEmployeeDetailController;   
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

        [ActionName("GetByIdAsync")]
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
        public async Task<ActionResult<DriverTemporaryLocationDTO>> CreateAsync(DriverTemporaryLocationDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }
                var result = await physicalEmployeeDetailController.GetByIdAsync((int)entity.Driver);

                if (result.Result is NotFoundResult)
                {
                    return UnprocessableEntity($"No driver was found with the requested foreign key");
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
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }
            [HttpPut("{id:int}")]
            public async Task<ActionResult<bool>> PutAsync(int id, DriverTemporaryLocationDTO entity)
            {
                try
                {
                    if (id != entity.Id)
                    {
                        return BadRequest("entity ID mismatch");
                    }

                    var entityToUpdate = await driverTemporaryLocationBlService.GetAsyncById(id);

                    if (entityToUpdate == null)
                    {
                        return NotFound($"entity with Id = {id} not found");
                    }

                    return await driverTemporaryLocationBlService.UpdateAsync(entity);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        e.Message);
                }
            }
        }
    
}
