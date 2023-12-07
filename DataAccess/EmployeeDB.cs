using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
namespace DataAccess
{
    public class EmployeeDB : IEmployeeDB
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeDB(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            employeeRepository.AddEmployee(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            employeeRepository.DeleteEmployee(employee);
        }
        public Employee GetEmployeeById(Guid id)
        {
            return employeeRepository.GetEmployeeById(id);
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }
        public Employee Authenticate(Guid id, string password)
        {
            return employeeRepository.Authenticate(id, password);
        }
    }
}
