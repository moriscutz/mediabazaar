using BusinessLogic.Classes;
using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces_For_Unit_Tests
{
    public interface IAdministration
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Employee GetEmployeeById(Guid id);
        List<Employee> GetAllEmployees();
        Employee Authenticate(string username, string password);
        void AddShift(Shift shift);
        void UpdateShift(Shift shift);
        void DeleteShift(Shift shift);
        Shift GetShiftById(Guid shiftId);
        List<Shift> GetAllShifts();
        List<Shift> GetShiftsForEmployeeById(Guid employeeId);
        List<Employee> SearchEmployeesByUsername(string username);
        List<Employee> SearchEmployeesByLastName(string lastName);
        bool IsShiftAvailable(DateTime date, ShiftType shiftType);
        void UpdateDatabaseWithNewSchedule(List<Shift> shifts);
        void AddAvailabilitiesToEmployee(Employee employee);
        void UpdateAvailabilitiesForEmployee(Employee employee);
        void UpdateAvailabilitiesForEmployeeById(Guid id);
        List<Availability> GetAvailabilitiesByEmployeeId(Guid id);
        List<Employee> GetAvailableEmployees(DateTime date, ShiftType shiftType);
        void DeleteAllShifts();
        Shift GetShiftByDateAndType(DateTime date, ShiftType shiftType);
        List<Shift> GetShiftsByDateAndType(DateTime date, ShiftType shiftType);
        Employee GetEmployeeByUsername(string username);
        List<Employee> GetAvailableEmployeesNotShifted(DateTime date);
        List<Shift> GetShiftsByDate(DateTime date);
        public List<Employee> GetAvailableEmployees(DateTime date);
    }
}
