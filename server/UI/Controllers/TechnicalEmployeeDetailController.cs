using Services.ServicesImplementation;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicalEmployeeDetailController : ControllerBase
    {
        private readonly ITechnicalEmployeeDetailBlService technicalEmployeeDetailBlService;
        public TechnicalEmployeeDetailController(ITechnicalEmployeeDetailBlService technicalEmployeeDetailBlService)
        {
            this.technicalEmployeeDetailBlService = technicalEmployeeDetailBlService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicalEmployeeDetailDTO>>> GetAsync()
        {
            try
            {
                return Ok(await technicalEmployeeDetailBlService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TechnicalEmployeeDetailDTO>> GetByIdAsync(int id)
        {
            try
            {
                var result = await technicalEmployeeDetailBlService.GetAsyncById(id);

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

        // POST api/<TechnicalEmployeeDetailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TechnicalEmployeeDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TechnicalEmployeeDetailDTO>> DeleteAsync(int id)

        {
            try
            {
                var entityToDelete = await technicalEmployeeDetailBlService.GetAsyncById(id);

                if (entityToDelete == null)
                {
                    return NotFound($"entity with Id = {id} not found");
                }

                return await technicalEmployeeDetailBlService.RemoveAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
