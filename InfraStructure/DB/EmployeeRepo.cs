using Domain.ApiModels.Employee;
using Domain.DbModels;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.DB
{
    public class EmployeeRepo : IEmployeeRepo
    {
        protected readonly EmployeeDbContext _dbContext;
        protected readonly DbSet<Employee> _dbSet;

        public EmployeeRepo(EmployeeDbContext employeeDbContext)
        {
            _dbContext = employeeDbContext;
            _dbSet = _dbContext.Set<Employee>();
        }

        // Add a new employee record
        public async Task<bool> AddEmployee(Employee employee)
        {
            await _dbSet.AddAsync(employee);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public Task<bool> AddEmployee(CreateEmployee employee)
        {
            throw new NotImplementedException();
        }

        // Delete an employee record by its ID
        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _dbSet.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _dbSet.Remove(employee);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        // Get an employee record by its ID
        public async Task<Employee> GetEmployee(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Get all employee records
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _dbSet.ToListAsync();
        }

        // Update an existing employee record
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var existingEmployee = await _dbSet.FindAsync(employee.EmployeeId);
            if (existingEmployee == null)
            {
                return false;
            }

            // Update the properties of the employee record
            _dbContext.Entry(existingEmployee).CurrentValues.SetValues(employee);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
