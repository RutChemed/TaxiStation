using Services.ServicesImplementation;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class OrderingTravelController : ControllerBase
    {
        private readonly IOrderingTravelBlService orderingTravelBlService;

        public OrderingTravelController(IOrderingTravelBlService orderingTravelBlService)
        {
            this.orderingTravelBlService = orderingTravelBlService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderingTravelDTO>>> GetAsync()
        {
            try
            {
                return Ok(await orderingTravelBlService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }
       
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderingTravelDTO>> GetByIdAsync(int id)
        {
            try
            {
                var result = await orderingTravelBlService.GetAsyncById(id);

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<OrderingTravelDTO>> DeleteAsync(int id)

        {
            try
            {
                var entityToDelete = await orderingTravelBlService.GetAsyncById(id);

                if (entityToDelete == null)
                {
                    return NotFound($"entity with Id = {id} not found");
                }

                return await orderingTravelBlService.RemoveAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
