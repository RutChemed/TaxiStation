using Services.ServicesImplementation;
using UI.ApiController;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicalEmployeeDetailController : ControllerBase,ITechnicalEmployeeDetailController
    {
        private readonly ITechnicalEmployeeDetailBlService technicalEmployeeDetailBlService;
        private readonly ILogger<TechnicalEmployeeDetailController> logger;

        public TechnicalEmployeeDetailController(ITechnicalEmployeeDetailBlService technicalEmployeeDetailBlService, ILogger<TechnicalEmployeeDetailController> logger)
        {
            this.technicalEmployeeDetailBlService = technicalEmployeeDetailBlService;
            this.logger = logger;   
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
        [ActionName("GetByIdAsync")]
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
        [HttpPost]
        public async Task<ActionResult<TechnicalEmployeeDetailDTO>> CreateAsync(TechnicalEmployeeDetailDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest();
                }

                var createdEntity = await technicalEmployeeDetailBlService.CreateAsync(entity);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   e.Message);
            }
        }

        // PUT api/<TechnicalEmployeeDetailController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TechnicalEmployeeDetailDTO value)
        {
            var result = await technicalEmployeeDetailBlService.UpdateAsync(value);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
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
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message   );
            }
        }
    }
}
