using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.ServicesApi;
using Services.ServicesImplementation;

namespace UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryTravelController : ControllerBase
    {
        private readonly IHistoryTravelBlService _historyTravelBlService;
        public HistoryTravelController(IHistoryTravelBlService historyTravelBlService)
        {
            _historyTravelBlService = historyTravelBlService;
        }
        [HttpGet]
        public Task<IEnumerable<HistoryTravelDTO>> Get()
        {
            try
            {
                return _historyTravelBlService.GetAllAsync();
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError,
                //"Error retrieving data from the database");
                return null;

            }
        }
 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HistoryTravelDTO>> GetEmployee(int id)
        {
            try
            {
                var result = await _historyTravelBlService.GetAsyncById(id);

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
//    [HttpPost]
//    public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
//    {
//        try
//        {
//            if (employee == null)
//            {
//                return BadRequest();
//            }

//            var emp = employeeRepository.GetEmployeeByEmail(employee.Email);

//            if (emp != null)
//            {
//                ModelState.AddModelError("email", "Employee email already in use");
//                return BadRequest(ModelState);
//            }

//            var createdEmployee = await employeeRepository.AddEmployee(employee);

//            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId },
//                createdEmployee);
//        }
//        catch (Exception)
//        {
//            return StatusCode(StatusCodes.Status500InternalServerError,
//                "Error retrieving data from the database");
//        }
//    }

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
        //public async Task<ActionResult<HistoryTravelDTO>> DeleteEmployee(int id)
        public async Task<ActionResult<bool>> DeleteEmployee(int id)

        {
            try
            {
                var employeeToDelete = await _historyTravelBlService.GetAsyncById(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _historyTravelBlService.RemoveAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}