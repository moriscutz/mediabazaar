using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IEmployeeDB
    {
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(Employee employee);
        public Employee GetEmployeeById(Guid id);
        public List<Employee> GetAllEmployees();
        public Employee Authenticate(string username, string password);
        public void AddEmployeeWithPreferences(Employee employee);
        public void UpdateEmployeeWithPreferences(Employee employee);
        public void UpdatePreferencesForEmployee(Guid ID, List<Preference> updatedPreferences);
    }
}
