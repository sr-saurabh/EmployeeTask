using Abstraction.Contracts;
using Domain.ApiModels.Salary;
using Domain.DbModels;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryContract _salaryContract;

        // Constructor to inject ISalaryContract
        public SalaryController(ISalaryContract salaryContract)
        {
            _salaryContract = salaryContract;
        }

        // GET: api/salary/{employeeId}/{salaryId}
        [HttpGet("{salaryId}")]
        public async Task<ActionResult<ApiSalary>> GetSalaryByEmployeeIdAsync(int salaryId)
        {
            var salary = await _salaryContract.GetSalariesByEmployeeIdAsync(salaryId);

            if (salary == null)
            {
                return NotFound();
            }

            return Ok(salary);
        }

        // GET: api/salary/{employeeId}
        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<List<ApiSalary>>> GetSalariesByEmployeeIdAsync(int employeeId)
        {
            var salaries = await _salaryContract.GetSalaryByEmployeeIdAsync(employeeId);

            if (salaries == null || salaries.Count == 0)
            {
                return NotFound();
            }

            return Ok(salaries);
        }

        // POST: api/salary
        [HttpPost]
        public async Task<IActionResult> AddSalaryAsync([FromBody] CreateSalary salary)
        {
            if (salary == null)
            {
                return BadRequest();
            }

            var addedSalary = await _salaryContract.AddSalaryAsync(salary);

            return Ok(addedSalary);
        }

        // PUT: api/salary
        [HttpPut]
        public async Task<ActionResult<ApiSalary>> UpdateSalaryAsync([FromBody] UpdateSalary salary)
        {
            if (salary == null)
            {
                return BadRequest();
            }

            var updatedSalary = await _salaryContract.UpdateSalaryAsync(salary);

            if (updatedSalary == null)
            {
                return NotFound();
            }

            return Ok(updatedSalary);
        }

        // DELETE: api/salary/{salaryId}
        [HttpDelete("{salaryId}")]
        public async Task<ActionResult> DeleteSalaryAsync(int salaryId)
        {
            var result = await _salaryContract.DeleteSalaryAsync(salaryId);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

