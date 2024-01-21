using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces_For_Unit_Tests;
namespace BusinessLogic.Algorithm
{
    public class ScheduleEmployeeAlgorithm
    {
        private readonly IAdministration administration;
        public List<DateTime> daysNotScheduled = new List<DateTime>();
        public int shiftsAlreadyScheduled = 0;

        public ScheduleEmployeeAlgorithm(IAdministration _administration)
        {
            administration = _administration;
        }

        public int GenerateSchedule(DateTime startDate)
        {
            var endDate = startDate.AddDays(6);
            var schedule = new List<Shift>();
            var assignedEmployeeIdsPerDay = new Dictionary<DateTime, HashSet<Guid>>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                assignedEmployeeIdsPerDay[date] = new HashSet<Guid>();

                var existingShiftsForDate = administration.GetShiftsByDate(date);

                foreach (ShiftType shiftType in Enum.GetValues(typeof(ShiftType)))
                {
                    var availableEmployees = administration.GetAvailableEmployees(date, shiftType);
                    bool shiftAssigned = false;

                    foreach (var employee in availableEmployees)
                    {
                        if (!existingShiftsForDate.Any(s => s.EmployeeID == employee.ID) &&
                            !assignedEmployeeIdsPerDay[date].Contains(employee.ID))
                        {
                            Guid shiftId = Guid.NewGuid();
                            var shift = new Shift(shiftId, date, shiftType, employee.ID);

                            schedule.Add(shift);
                            assignedEmployeeIdsPerDay[date].Add(employee.ID);
                            shiftAssigned = true;
                            break; 
                        }
                    }

                    if (!shiftAssigned && !daysNotScheduled.Contains(date))
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
