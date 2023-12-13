using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class Administration
    {
        private readonly IEmployeeDB employeeDB;
        private readonly IShiftDB shiftDB;

        public Administration(IEmployeeDB employeeDB, IShiftDB shiftDB)
        {
            this.employeeDB = employeeDB;
            this.shiftDB = shiftDB;
        }

        public void AddEmployee(Employee employee)
        {
            if (employee.Preferences == null)
                employeeDB.AddEmployee(employee);
            else
                employeeDB.AddEmployeeWithPreferences(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            employeeDB.UpdateEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            employeeDB.DeleteEmployee(employee);
        }
        public Employee GetEmployeeById(Guid id)
        {
            var employee = employeeDB.GetEmployeeById(id);
            if (employee != null && employee.Shifts == null) ;
            {
                employee.Shifts = new List<Shift>();
            }
            if (employee.Preferences == null)
            {
                employee.Preferences = new List<Preference>();
            }
            return employee;
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeDB.GetAllEmployees();
        }
        public Employee Authenticate(string username, string password)
        {
            return employeeDB.Authenticate(username, password);
        }

        public void AddShift(Shift shift)
        {
            shiftDB.AddShift(shift);
        }
        public void UpdateShift(Shift shift)
        {
            shiftDB.UpdateShift(shift);
        }
        public void DeleteShift(Shift shift)
        {
            shiftDB.DeleteShift(shift);
        }
        public Shift GetShiftById(Guid shiftId)
        {
            return shiftDB.GetShiftById(shiftId);
        }
        public List<Shift> GetAllShifts()
        {
            return shiftDB.GetAllShifts();
        }

        public List<Shift> GetShiftsForEmployeeById(Guid employeeId)
        {
            return shiftDB.GetShiftsForEmployeeById(employeeId);
        }

        public List<Preference> GetPreferencesByEmployeeId(Guid employeeId)
        {
            return shiftDB.GetPreferencesByEmployeeId(employeeId);
        }
        public List<Preference> GetPreferencesByDayOfWeek(int dayOfWeek)
        {
            return shiftDB.GetPreferencesByDayOfWeek(dayOfWeek);
        }
        public void AddPreference(Preference preference)
        {
            shiftDB.AddPreference(preference);
        }
        public void UpdatePreference(Preference preference)
        {
            shiftDB.UpdatePreference(preference);
        }
    }
}
