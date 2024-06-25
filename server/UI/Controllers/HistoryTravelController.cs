using Services.ServicesImplementation;
using UI.ApiController;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryTravelController : ControllerBase
    {
        private readonly IHistoryTravelBlService historyTravelBlService;
        private readonly ILogger<HistoryTravelController> logger;
        private readonly IPhysicalEmployeeDetailController physicalEmployeeDetailController;


        public HistoryTravelController(IHistoryTravelBlService historyTravelBlService, ILogger<HistoryTravelController> logger, IPhysicalEmployeeDetailController physicalEmployeeDetailController)
        {
            this.historyTravelBlService = historyTravelBlService;
            this.logger = logger;
            this.physicalEmployeeDetailController = physicalEmployeeDetailController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryTravelDTO>>> GetAsync()
        {
            try
            {
                return Ok(await historyTravelBlService.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }
        [ActionName("GetByIdAsync")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HistoryTravelDTO>> GetByIdAsync(int id)
        {
            try
            {
                var result = await historyTravelBlService.GetAsyncById(id);

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
        public async Task<ActionResult<DriverTemporaryLocationDTO>> CreateEmployee(HistoryTravelDTO entity)
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
                var createdEntity = await historyTravelBlService.CreateAsync(entity);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   e.Message);
            }
        }
     
        //    [HttpPut("{id:int}")]
        //    public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        //    {
        //        try
        //        {
        //            if (id != employee.EmployeeId)
        //            {
        //                return BadRequest("Employee ID mismatch");
        //            }

        //            var employeeToUpdate = await employeeRepository.GetEmployee(id);

        //            if (employeeToUpdate == null)
        //            {
        //                return NotFound($"Employee with Id = {id} not found");
        //            }

        //            return await employeeRepository.UpdateEmployee(employee);
        //        }
        //        catch (Exception)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError,
        //                "Error updating data");
        //        }
        //    }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<HistoryTravelDTO>> DeleteEmployee(int id)

        {
            try
            {
                var employeeToDelete = await historyTravelBlService.GetAsyncById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await historyTravelBlService.RemoveAsync(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }

    }
}