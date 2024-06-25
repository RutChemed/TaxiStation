using Microsoft.AspNetCore.Mvc;
using Services.ServicesImplementation;
using UI.ApiController;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class OrderingTravelController : ControllerBase
    {
        private readonly IOrderingTravelBlService orderingTravelBlService;
        private readonly ILogger<OrderingTravelController> logger;
        private readonly IPhysicalEmployeeDetailController physicalEmployeeDetailController;

        public OrderingTravelController(IOrderingTravelBlService orderingTravelBlService, ILogger<OrderingTravelController> logger, IPhysicalEmployeeDetailController physicalEmployeeDetailController)
        {
            this.orderingTravelBlService = orderingTravelBlService;
            this.logger = logger;
            this.physicalEmployeeDetailController = physicalEmployeeDetailController;
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
        public async Task<ActionResult<OrderingTravelDTO>> CreateEmployee(OrderingTravelDTO entity)
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
                var createdEntity = await orderingTravelBlService.CreateAsync(entity);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   e.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [ActionName("GetByIdAsync")]
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
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }
    }
}
