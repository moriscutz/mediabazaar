using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Algorithm
{
    public class AutomaticScheduling
    {
        private readonly Administration administration;
        public AutomaticScheduling(IEmployeeDB employeeDB, IShiftDB shiftDB)
        {
            administration = new Administration(employeeDB, shiftDB);
        }

        public AutomaticScheduling(Administration _administration) 
        {
            administration = _administration;
        }

        private const int MaxShiftsPerDay = 2;
        private const int MaxShiftsPerWeek = 5;
        private const int EmployeesNeededPerShift = 3;

        public List<Shift> ScheduleShifts()
        {
            var schedulingPeriod = DetermineSchedulingPeriod();
            var allEmployees = administration.GetAllEmployees();
            var shifts = InitializeShifts(schedulingPeriod);

            
            foreach (var shift in shifts)
            {
                AssignEmployeesToShift(shift, allEmployees);
            }

            
            foreach (var employee in allEmployees)  
            {
                TryToAccommodatePreferences(employee, shifts);
            }

            
            HandleShiftShortage(shifts, allEmployees);

            return shifts;
        }

        private List<Shift> InitializeShifts((DateTime startDate, DateTime endDate) schedulingPeriod)
        {
            var shifts = new List<Shift>();
            for (DateTime date = schedulingPeriod.startDate; date <= schedulingPeriod.endDate; date = date.AddDays(1))
            {
                foreach (ShiftType shiftType in Enum.GetValues(typeof(ShiftType)))
                {
                    shifts.Add(new Shift(Guid.NewGuid(), date, shiftType, Guid.Empty));
                }
            }
            return shifts;
        }
        private (DateTime startDate, DateTime endDate) DetermineSchedulingPeriod()
        {
            DateTime today = DateTime.Today;
            int daysUntilNextNextMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 14) % 7;
                daysUntilNextNextMonday = daysUntilNextNextMonday == 0 ? 7 : daysUntilNextNextMonday; // Ensure it's not zero

            DateTime startDate = today.AddDays(daysUntilNextNextMonday);
            DateTime endDate = startDate.AddDays(6); // One week later

            return (startDate, endDate);
        }

        private void AssignEmployeesToShift(Shift shift, List<Employee> employees)
        {
            var assignedEmployees = 0;
            foreach (var employee in employees)
            {
                if (assignedEmployees >= EmployeesNeededPerShift)
                    break;

                if (CanWorkShift(employee, shift))
                {
                    shift.EmployeeID = employee.ID;
                    employee.Shifts.Add(shift);
                    assignedEmployees++;
                }
            }
        }

        private void TryToAccommodatePreferences(Employee employee, List<Shift> shifts)
        {
            var employeePreferences = administration.GetPreferencesByEmployeeId(employee.ID);

            foreach (var preference in employeePreferences)
            {
                // Find the shift that matches the preference day
                var currentShiftOnPreferredDay = employee.Shifts.FirstOrDefault(s => s.Date.DayOfWeek == (DayOfWeek)preference.DayOfWeek);

                if (currentShiftOnPreferredDay != null && currentShiftOnPreferredDay.Type != preference.ShiftType)
                {
                    // Try to find another employee who has a shift that matches this employee's preference and is willing to swap
                    var swapCandidate = FindSwapCandidate(employee, preference, shifts);

                    if (swapCandidate != null)
                    {
                        // Perform the swap
                        SwapShifts(employee, swapCandidate, currentShiftOnPreferredDay, shifts);
                    }
                }
            }
        }

        private void SwapShifts(Employee employee1, Employee employee2, Shift shiftToSwap, List<Shift> shifts)
        {
            // Find the corresponding shift for employee2 to swap
            var swapShift = employee2.Shifts.FirstOrDefault(s => s.Date == shiftToSwap.Date && s.Type == shiftToSwap.Type);

            if (swapShift != null)
            {
                // Swap the shifts in the in-memory collection
                employee1.Shifts.Remove(shiftToSwap);
                employee1.Shifts.Add(swapShift);
                employee2.Shifts.Remove(swapShift);
                employee2.Shifts.Add(shiftToSwap);

                // Update the EmployeeID for both shifts
                shiftToSwap.EmployeeID = employee2.ID;
                swapShift.EmployeeID = employee1.ID;

                // Update the shifts in the database
                UpdateShiftInDatabase(shiftToSwap);
                UpdateShiftInDatabase(swapShift);
            }
        }

        private void UpdateShiftInDatabase(Shift shift)
        { 
           administration.UpdateShift(shift);
        }

        private Employee FindSwapCandidate(Employee employee, Preference preference, List<Shift> shifts)
        {
            foreach (var shift in shifts)
            {
                if (shift.Date.DayOfWeek == (DayOfWeek)preference.DayOfWeek && shift.Type == preference.ShiftType)
                {
                    var potentialSwapEmployee = administration.GetAllEmployees().FirstOrDefault(e => e.ID == shift.EmployeeID);

                    if (potentialSwapEmployee != null && potentialSwapEmployee.ID != employee.ID)
                    {
                        // Ensure that the swap does not violate any shift constraints for the swap candidate
                        if (CanSwapShifts(potentialSwapEmployee, shift))
                        {
                            return potentialSwapEmployee;
                        }
                    }
                }
            }
            return null;
        }

        private bool CanSwapShifts(Employee employee, Shift proposedShift)
        {

            if (employee.Shifts == null)
            {
                employee.Shifts = new List<Shift>();
            }
            // Check if adding the proposed shift will exceed the maximum shifts per day
            if (employee.Shifts.Count(s => s.Date.Date == proposedShift.Date.Date) >= MaxShiftsPerDay)
            {
                return false;
            }

            // Calculate the start of the week for the proposed shift
            var startOfWeek = proposedShift.Date.Date.AddDays(-(int)proposedShift.Date.DayOfWeek + (int)DayOfWeek.Monday);

            // Check if adding the proposed shift will exceed the maximum shifts per week
            if (employee.Shifts.Count(s => s.Date.Date >= startOfWeek && s.Date.Date < startOfWeek.AddDays(7)) >= MaxShiftsPerWeek)
            {
                return false;
            }

            return true;
        }

        private void HandleShiftShortage(List<Shift> shifts, List<Employee> employees)
        {
            foreach (var shift in shifts)
            {
                while (shift.EmployeeID == Guid.Empty || shifts.Count(s => s.Date == shift.Date && s.Type == shift.Type) < EmployeesNeededPerShift)
                {
                    var employeeToAssign = employees
                        .Where(e => CanWorkShift(e, shift))
                        .OrderBy(e => e.Shifts.Count(s => s.Date >= shift.Date && s.Date < shift.Date.AddDays(7)))
                        .FirstOrDefault();

                    if (employeeToAssign != null)
                    {
                        shift.EmployeeID = employeeToAssign.ID;
                        employeeToAssign.Shifts.Add(shift);
                    }
                    else
                    {
                        // Log or handle the case where no available employee can be assigned
                        break;
                    }
                }
            }
        }

        private double CalculateSchedulingScore(List<Shift> shifts)
        {
            double score = 0;
            foreach (var shift in shifts)
            {
                if (shift.EmployeeID != Guid.Empty)
                {
                    score += 1; // +1 point for each filled shift
                    var employeePreferences = administration.GetPreferencesByEmployeeId(shift.EmployeeID);
                    if (employeePreferences.Any(p => p.DayOfWeek == (int)shift.Date.DayOfWeek && p.ShiftType == shift.Type))
                    {
                        score += 0.5; // +0.5 points for matching preference
                    }
                }
            }
            return score;
        }

        private bool CanWorkShift(Employee employee, Shift shift)
        {

            if (employee.Shifts == null)
            {
                employee.Shifts = new List<Shift>();
            }

            if (employee.Shifts.Count(s => s.Date.Date == shift.Date.Date) >= MaxShiftsPerDay)
                return false;

            var startOfWeek = shift.Date.Date.AddDays(-(int)shift.Date.DayOfWeek + (int)DayOfWeek.Monday);
            if (employee.Shifts.Count(s => s.Date.Date >= startOfWeek && s.Date.Date < startOfWeek.AddDays(7)) >= MaxShiftsPerWeek)
                return false;

            return true;
        }


    }
}
