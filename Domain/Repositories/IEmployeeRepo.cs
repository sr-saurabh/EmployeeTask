using Domain.ApiModels.Employee;
using Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEmployeeRepo
    {
        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteAsync(int id);
    }
}
