using Abstraction.Contracts;
using AutoMapper;
using Domain.ApiModels.Salary;
using Domain.DbModels;
using Domain.Repositories;

namespace Abstraction.Providers
{
    public class SalaryProvider : ISalaryContract
    {
        private readonly ISalaryRepo _salaryRepo;
        private readonly IMapper _mapper;


        // Constructor to inject ISalaryRepo
        public SalaryProvider(ISalaryRepo salaryRepo, IMapper mapper)
        {
            _salaryRepo = salaryRepo;
            _mapper = mapper;
        }

        // Add a new salary record
        public async Task<ApiSalary> AddSalaryAsync(CreateSalary salary)
        {
            var salaryEntity = _mapper.Map<Salary>(salary);

            var result = await _salaryRepo.AddSalary(salaryEntity);

            if (result==null)
            {
                throw new Exception("Failed to add salary.");
            }
            return _mapper.Map<ApiSalary>(result);
        }

        // Delete a salary record by its ID
        public async Task<bool> DeleteSalaryAsync(int salaryId)
        {
            var result = await _salaryRepo.DeleteAsync(salaryId);

            if (!result)
            {
                throw new Exception("Failed to delete salary.");
            }

            return result;
        }

        // Get salary by employee and salary ID
        public async Task<ApiSalary> GetSalariesByEmployeeIdAsync(int salaryId)
        {
            var salary = await _salaryRepo.GetSalary(salaryId);

            if (salary == null)
            {
                throw new Exception("Salary not found.");
            }

            return _mapper.Map<ApiSalary>(salary);

        }

        // Get all salaries by employee ID
        public async Task<List<ApiSalary>> GetSalaryByEmployeeIdAsync(int employeeId)
        {
            var salaries = await _salaryRepo.GetSalaries(employeeId);

            if (salaries == null || !salaries.Any())
            {
                throw new Exception("No salaries found for the employee.");
            }

            return _mapper.Map<List<ApiSalary>>(salaries);

        }

        // Update an existing salary record
        public async Task<ApiSalary> UpdateSalaryAsync(UpdateSalary salary)
        {
            var salaryEntity = _mapper.Map<Salary>(salary);

            var result = await _salaryRepo.UpdateSalary(salaryEntity);

            if (!result)
            {
                throw new Exception("Failed to update salary.");
            }

            return _mapper.Map<ApiSalary>(result);

        }
    }
}
