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
        private readonly IDateService dateService; // Optional for testing

        public Administration(IEmployeeDB employeeDB, IShiftDB shiftDB)
        {
            this.employeeDB = employeeDB;
            this.shiftDB = shiftDB;
        }
        // Overloaded constructor for testing

        public Administration(IEmployeeDB employeeDB, IShiftDB shiftDB, IDateService dateService) : this(employeeDB, shiftDB)
        {
            this.dateService = dateService;
        }
        public interface IDateService
        {
            DateTime Today { get; }
        }
        public class DateService : IDateService
        {
            public DateTime Today => DateTime.Today;
        }
        public void ScheduleShiftsBasedOnPreferences()
        {
            var schedulingPeriod = DetermineSchedulingPeriod();
            var allEmployees = GetAllEmployees();

            foreach (var employee in allEmployees)
            {
                var preferences = GetPreferencesByEmployeeId(employee.ID);

                for (DateTime date = schedulingPeriod.startDate; date <= schedulingPeriod.endDate; date = date.AddDays(1))
                {
                    var dayOfWeek = (int)date.DayOfWeek;
                    var preference = preferences.FirstOrDefault(p => p.DayOfWeek == dayOfWeek);

                    if (preference != null)
                    {
                        var existingShift = GetShiftsForEmployeeById(employee.ID)
                                                   .FirstOrDefault(s => s.Date.Date == date.Date);

                        if (existingShift == null)
                        {
                            var newShift = new Shift(Guid.NewGuid(), date, preference.ShiftType, employee.ID);
                            AddShift(newShift);
                        }
                    }
                }
            }
        }

        // New method to determine the scheduling period, in our case 1 week scheduling period starting 2 weeks from current day
        private (DateTime startDate, DateTime endDate) DetermineSchedulingPeriod()
        {
            DateTime today = DateTime.Today;
            int daysUntilNextNextMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 14) % 7;
            daysUntilNextNextMonday = daysUntilNextNextMonday == 0 ? 7 : daysUntilNextNextMonday; // Ensure it's not zero

            DateTime startDate = today.AddDays(daysUntilNextNextMonday);
            DateTime endDate = startDate.AddDays(6); // One week later

            return (startDate, endDate);
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
        public void UpdateEmployeeWithPreferences(Employee employee)
        {
            employeeDB.UpdateEmployeeWithPreferences(employee);
        }

        public void UpdatePreferencesForEmployee(Guid ID, List<Preference> updatedPreferences)
        {
            employeeDB.UpdatePreferencesForEmployee(ID, updatedPreferences);
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
    }
}
