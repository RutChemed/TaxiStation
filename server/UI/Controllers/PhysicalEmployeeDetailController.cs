using Services.ServicesImplementation;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhysicalEmployeeDetailController : ControllerBase
    {
        private readonly IPhysicalEmployeeDetailBlService physicalEmployeeDetailBlService;
        public PhysicalEmployeeDetailController(IPhysicalEmployeeDetailBlService physicalEmployeeDetailBlService)
        {
            this.physicalEmployeeDetailBlService = physicalEmployeeDetailBlService;
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

        // POST api/<PhysicalEmployeeDetailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PhysicalEmployeeDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
