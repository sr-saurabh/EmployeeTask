using Domain.ApiModels.Employee;

namespace Abstraction.Contracts
{
    public interface IEmployeeContract
    {
        Task<IEnumerable<ApiEmployee>> GetAllEmployeesAsync();

        // Get an employee by ID
        Task<ApiEmployee> GetEmployeeByIdAsync(int id);

        // Add a new employee
        Task<ApiEmployee> AddEmployeeAsync(CreateEmployee employee);

        // Update an existing employee
        Task<bool> UpdateEmployeeAsync(UpdateEmployee employee);

        // Delete an employee by ID
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
