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
    public class ScheduleEmployeeAlgorithm
    {
        private readonly Administration administration;
        public List<DateTime> daysNotScheduled = new List<DateTime>();
        public int shiftsAlreadyScheduled = 0;
        public ScheduleEmployeeAlgorithm(Administration _administration)
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

                foreach (ShiftType shiftType in Enum.GetValues(typeof(ShiftType)))
                {
                    var existingShift = administration.GetShiftByDateAndType(date, shiftType);
                    if (existingShift == null)
                    {
                        var availableEmployees = administration.GetAvailableEmployees(date, shiftType);
                        var assignableEmployees = availableEmployees.Where(e => !assignedEmployeeIdsPerDay[date].Contains(e.ID)).ToList();

                        if (assignableEmployees.Any())
                        {
                            var employee = assignableEmployees[new Random().Next(assignableEmployees.Count)];
                            Guid shiftId = Guid.NewGuid();
                            var shift = new Shift(shiftId, date, shiftType, employee.ID);

                            schedule.Add(shift);
                            assignedEmployeeIdsPerDay[date].Add(employee.ID); 
                        }
                        else
                        {
                            if (!daysNotScheduled.Contains(date))
                                daysNotScheduled.Add(date);
                        }
                    }
                    else
                    {
                        shiftsAlreadyScheduled++;
                    }
                }
            }

            foreach (var shift in schedule)
            {
                administration.AddShift(shift);
            }

            return schedule.Count();
        }


    }
}
