using Domain.DbModels;
using Domain.Repositories;
using InfraStructure;
using Microsoft.EntityFrameworkCore;

public class SalaryRepo : ISalaryRepo
{
    protected readonly EmployeeDbContext _dbContext;
    protected readonly DbSet<Salary> _dbSet;

    public SalaryRepo(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Salary>();
    }

    // Add a new salary record
    public async Task<Salary>? AddSalary(Salary salary)
    {
        var newSalary = await _dbSet.AddAsync(salary);
        _dbContext.SaveChanges();
        return newSalary.Entity;
    }

    // Delete a salary record by its ID
    public async Task<bool> DeleteAsync(int id)
    {
        var salary = await _dbSet.FindAsync(id);
        if (salary == null)
        {
            return false;
        }

        _dbSet.Remove(salary);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    // Get all salary records for a specific employee
    public async Task<IEnumerable<Salary>> GetSalaries(int employeeId)
    {
        return await _dbSet.Where(s => s.EmployeeId == employeeId).ToListAsync();
    }

    // Get a salary record by its ID
    public async Task<Salary> GetSalary(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    // Update an existing salary record
    public async Task<bool> UpdateSalary(Salary salary)
    {
        var existingSalary = await _dbSet.FindAsync(salary.SalaryId);
        if (existingSalary == null)
        {
            return false;
        }

        // Update the properties of the salary record
        _dbContext.Entry(existingSalary).CurrentValues.SetValues(salary);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}
