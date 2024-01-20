using BusinessLogic.Enums;
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
        private readonly IAvailabilityDB availabilityDB;

        public Administration(IEmployeeDB employeeDB, IShiftDB shiftDB, IAvailabilityDB availabilityDB)
        {
            this.employeeDB = employeeDB;
            this.shiftDB = shiftDB;
            this.availabilityDB = availabilityDB;
        }

        public void AddEmployee(Employee employee)
        {
            employeeDB.AddEmployee(employee);
            if (employee.Availabilities != null)
                availabilityDB.AddAvailabilitiesToEmployee(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            employeeDB.UpdateEmployee(employee);
            if(employee.Availabilities != null)
            {
                availabilityDB.UpdateAvailabilitiesForEmployee(employee);
            }
                
        }
        public void DeleteEmployee(Employee employee)
        {
            employeeDB.DeleteEmployee(employee);
        }
        public Employee GetEmployeeById(Guid id)
        {
            var employee = employeeDB.GetEmployeeById(id);

            if (employee != null)
            {
                if (employee.Shifts == null)
                {
                    employee.Shifts = new List<Shift>();
                }
                if (employee.Availabilities == null)
                {
                    employee.Availabilities = new List<Availability>();
                }
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

        public List<Employee> SearchEmployeesByUsername(string username)
        {
            var employees = employeeDB.GetAllEmployees();
            return employees.FindAll(emp => emp.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public List<Employee> SearchEmployeesByLastName(string lastName) 
        {
            var employees = employeeDB.GetAllEmployees();
            return employees.FindAll(emp => emp.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }
        public bool IsShiftAvailable(DateTime date, ShiftType shiftType)
        {
            return shiftDB.CountShiftsOnDateAndType(date, shiftType) < 3; // Example threshold
        }

        public void UpdateDatabaseWithNewSchedule(List<Shift> shifts)
        {
            int count=0;
            foreach (var shift in shifts)
            {

                if (shift.EmployeeID != Guid.Empty) // Check if shift is assigned
                {
                    var alreadyExistingShift = GetShiftById(shift.ShiftId);
                    if (alreadyExistingShift != null)
                        shiftDB.UpdateShift(shift);
                    else
                        shiftDB.AddShift(shift);
                }
                else
                {
                    count++;
                }
                System.Diagnostics.Debug.WriteLine($"{count}");
            }
        }
        public void AddAvailabilitiesToEmployee(Employee employee)
        {
            availabilityDB.AddAvailabilitiesToEmployee(employee);
        }
        public void UpdateAvailabilitiesForEmployee(Employee employee)
        {
            availabilityDB.UpdateAvailabilitiesForEmployee(employee);
        }
        public void UpdateAvailabilitiesForEmployeeById(Guid id)
        {
            availabilityDB.UpdateAvailabilitiesForEmployeeById(id);
        }
        public List<Availability> GetAvailabilitiesByEmployeeId(Guid id)
        {
            return availabilityDB.GetAvailabilitiesByEmployeeId(id);
        }
        public List<Employee> GetAvailableEmployees(DateTime date, ShiftType shiftType)
        {
            
            int dayOfWeek = (int)date.DayOfWeek;
            dayOfWeek = dayOfWeek == 0 ? 6 : dayOfWeek - 1; 

            return availabilityDB.GetAvailableEmployeesByDayAndShift(dayOfWeek, shiftType);
        }

        public void DeleteAllShifts()
        {
            shiftDB.DeleteAllShifts();
        }

        public Shift GetShiftByDateAndType(DateTime date,ShiftType shiftType)
        {
            return shiftDB.GetShiftByDateAndType(date, shiftType);
        }

        public List<Shift> GetShiftsByDateAndType(DateTime date, ShiftType shiftType)
        {
            return shiftDB.GetShiftsByDateAndType(date, shiftType);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return employeeDB.GetEmployeeByUsername(username);
        }
    }
}
