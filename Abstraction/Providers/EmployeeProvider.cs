using Abstraction.Contracts;
using AutoMapper;
using Domain.ApiModels.Employee;
using Domain.DbModels;
using Domain.Repositories;

namespace Abstraction.Providers
{
    public class EmployeeProvider : IEmployeeContract
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeProvider(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        // Add a new employee (returns a boolean indicating success)
        public async Task<bool> AddEmployee(CreateEmployee employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            return await _employeeRepo.AddEmployee(employeeEntity);
        }

        // Add a new employee and return the created employee in API model format
        public async Task<ApiEmployee> AddEmployeeAsync(CreateEmployee employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            var result = await _employeeRepo.AddEmployee(employeeEntity);

            if (!result)
            {
                throw new Exception("Failed to add employee.");
            }

            return _mapper.Map<ApiEmployee>(employeeEntity);
        }

        // Delete an employee by their ID
        public async Task<bool> DeleteAsync(int id)
        {
            return await _employeeRepo.DeleteAsync(id);
        }

        // Delete an employee and return a boolean indicating success
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepo.DeleteAsync(id);
        }

        // Get all employees and return a list of API model employees
        public async Task<IEnumerable<ApiEmployee>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepo.GetEmployees();
            return _mapper.Map<IEnumerable<ApiEmployee>>(employees);
        }

        // Get a single employee by their ID
        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepo.GetEmployee(id);
        }

        // Get a single employee by their ID and return in API model format
        public async Task<ApiEmployee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepo.GetEmployee(id);

            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            return _mapper.Map<ApiEmployee>(employee);
        }

        // Get all employees and return in DB model format
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepo.GetEmployees();
        }

        // Update an employee and return a boolean indicating success
        public async Task<bool> UpdateEmployee(UpdateEmployee employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            return await _employeeRepo.UpdateEmployee(employeeEntity);
        }

        // Update an employee and return the updated employee in API model format
        public async Task<bool> UpdateEmployeeAsync(UpdateEmployee employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            var result = await _employeeRepo.UpdateEmployee(employeeEntity);

            if (!result)
            {
                throw new Exception("Failed to update employee.");
            }

            return result;
        }
    }
}
