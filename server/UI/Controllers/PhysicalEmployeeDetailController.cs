using Microsoft.Extensions.Logging;
using Services.ServicesImplementation;
using UI.ApiController;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhysicalEmployeeDetailController : ControllerBase,IPhysicalEmployeeDetailController
    {
        private readonly IPhysicalEmployeeDetailBlService physicalEmployeeDetailBlService;
        private readonly ILogger<PhysicalEmployeeDetailController> logger;
        private readonly ITechnicalEmployeeDetailController technicalEmployeeDetailController;

        public PhysicalEmployeeDetailController(IPhysicalEmployeeDetailBlService physicalEmployeeDetailBlService, ILogger<PhysicalEmployeeDetailController> logger,ITechnicalEmployeeDetailController technicalEmployeeDetailController)
        {
            this.physicalEmployeeDetailBlService = physicalEmployeeDetailBlService;
            this.logger = logger; 
            this.technicalEmployeeDetailController = technicalEmployeeDetailController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhysicalEmployeeDetailDTO>>> GetAsync()
        {
            try
            {
                return Ok(await physicalEmployeeDetailBlService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }
        [ActionName("GetByIdAsync")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PhysicalEmployeeDetailDTO>> GetByIdAsync(int id)
        {
            try
            {
                var result = await physicalEmployeeDetailBlService.GetAsyncById(id);
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
        [ActionName("GetAsyncByEmployee")]
        [HttpGet("employee/{id:int}")]
        public async Task<ActionResult<PhysicalEmployeeDetailDTO>> GetAsyncByEmployee(int id)
        {
            try
            {
                var result = await physicalEmployeeDetailBlService.GetAsyncByEmployee(id);
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
        // POST api/<PhysicalEmployeeDetailController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        //[HttpPost]
        //public async Task<ActionResult<PhysicalEmployeeDetailDTO>> CreateAsync(PhysicalEmployeeDetailDTO entity)
        //{
        //    try
        //    {
        //        if (entity == null)
        //        {
        //            return BadRequest();
        //        }
        //        var result = await technicalEmployeeDetailController.GetByIdAsync((int)entity.Employee);

        //        if (result.Result is NotFoundResult)
        //        {
        //            return UnprocessableEntity($"No driver was found with the requested foreign key");
        //        }

        //        var createdEntity = await physicalEmployeeDetailBlService.CreateAsync(entity);

        //        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdEntity.Id }, createdEntity);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //           e.Message);
        //    }
        //}

        // PUT api/<PhysicalEmployeeDetailController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PhysicalEmployeeDetailDTO value)
        {
            //if (value == null || id != value.Id)
            //{
            //    return BadRequest("Invalid data.");
            //}

            var result = await physicalEmployeeDetailBlService.UpdateAsync(value);

            if (result)
            {
                return Ok("Update successful.");
            }
            return NotFound("Employee not found or technical employee ID does not exist.");
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PhysicalEmployeeDetailDTO>> DeleteAsync(int id)

        {
            try
            {
                var entityToDelete = await physicalEmployeeDetailBlService.GetAsyncById(id);

                if (entityToDelete == null)
                {
                    return NotFound($"entity with Id = {id} not found");
                }

                return await physicalEmployeeDetailBlService.RemoveAsync(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
            }
        }
    }
}
