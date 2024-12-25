using Domain.ApiModels.Salary;
using Domain.DbModels;

namespace Abstraction.Contracts
{
    public interface ISalaryContract
    {
        Task<ApiSalary> GetSalariesByEmployeeIdAsync(int salaryId);
        Task<List<ApiSalary>> GetSalaryByEmployeeIdAsync(int employeeId);

        // Add a new salary record
        Task<ApiSalary> AddSalaryAsync(CreateSalary salary);

        // Update an existing salary record
        Task<ApiSalary> UpdateSalaryAsync(UpdateSalary salary);

        // Delete a salary record by its ID
        Task<bool> DeleteSalaryAsync(int salaryId);

    }
}
