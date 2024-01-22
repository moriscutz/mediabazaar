using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using BusinessLogic.Interfaces_For_Unit_Tests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Algorithm
{
    public class ScheduleEmployeeAlgorithm
    {
        private readonly IAdministration administration;
        public int shiftsAlreadyScheduled = 0;
        public int peoplePerShiftType = 3;
        public int daysWithInsufficientStaff = 0;
        public List<DateTime> daysNotScheduled = new List<DateTime>();
        public ScheduleEmployeeAlgorithm(IAdministration _administration)
        {
            administration = _administration;
        }

        public int GenerateSchedule(DateTime startDate)
        {
            var endDate = startDate.AddDays(6);
            var schedule = new List<Shift>();
            const int peoplePerShiftType = 3;
            const int totalShiftsPerDay = 3 * peoplePerShiftType ; // shift types * peoplePerShiftType 
            var shiftTypes = Enum.GetValues(typeof(ShiftType)).Cast<ShiftType>().ToList();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var availableEmployees = administration.GetAvailableEmployees(date);


                if (availableEmployees == null)
                {
                    availableEmployees = new List<Employee>();
                }

                availableEmployees = availableEmployees.OrderBy(e => Guid.NewGuid()).ToList();

                var existingShiftsForDate = administration.GetShiftsByDate(date);

                var assignedEmployeeIdsForDay = new HashSet<Guid>();
                int totalAssignedForDay = 0; 

                foreach (var employee in availableEmployees)
                {
                    if (totalAssignedForDay >= totalShiftsPerDay)
                    {
                        break; 
                    }

                    if (!existingShiftsForDate.Any(s => s.EmployeeID == employee.ID) &&
                        !assignedEmployeeIdsForDay.Contains(employee.ID))
                    {
                        var shiftType = shiftTypes[totalAssignedForDay % shiftTypes.Count];
                        var shift = new Shift(Guid.NewGuid(), date, shiftType, employee.ID);
                        schedule.Add(shift);
                        assignedEmployeeIdsForDay.Add(employee.ID);
                        totalAssignedForDay++;
                    }
                }

                if (totalAssignedForDay < totalShiftsPerDay)
                {
                    daysWithInsufficientStaff++;
                    if (!daysNotScheduled.Contains(date))
                    {
                        daysNotScheduled.Add(date);
                    }
                }

                shiftsAlreadyScheduled += existingShiftsForDate.Count;
            }

            foreach (var shift in schedule)
            {
                administration.AddShift(shift);
            }

            return schedule.Count();
        }



    }
}
