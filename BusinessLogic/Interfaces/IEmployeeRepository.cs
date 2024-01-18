using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee GetEmployeeById(Guid id);
        List<Employee> GetAllEmployees();
        Employee Authenticate(string username, string password);
    }
}
