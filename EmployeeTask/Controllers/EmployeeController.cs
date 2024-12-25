using Abstraction.Contracts;
using Domain.ApiModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeContract _employeeContract;

        public EmployeeController(IEmployeeContract employeeContract)
        {
            _employeeContract = employeeContract;
        }

        // GET: api/Salary/employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeContract.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/Salary/employees/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeContract.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Salary/employees
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] CreateEmployee createEmployee)
        {
            if (createEmployee == null)
            {
                return BadRequest("Employee data is null");
            }

            var addedEmployee = await _employeeContract.AddEmployeeAsync(createEmployee);
            return Ok(addedEmployee);
        }

        // PUT: api/Salary/employees/{id}
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployee updateEmployee)
        {
            if (updateEmployee == null)
            {
                return BadRequest("Employee data is invalid");
            }

            var result = await _employeeContract.UpdateEmployeeAsync(updateEmployee);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE: api/Salary/employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeContract.DeleteEmployeeAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

    }
}
