using Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ISalaryRepo
    {
        Task<Salary> GetSalary(int id);
        Task<IEnumerable<Salary>> GetSalaries(int employeeId);
        Task<Salary> AddSalary(Salary salary);
        Task<bool> UpdateSalary(Salary salary);
        Task<bool> DeleteAsync(int id);
    }
}
