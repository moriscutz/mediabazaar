using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class Availability
    {
        public Guid EmployeeID { get; set; }
        public DaysOfWeek DayOfWeek { get; set; }
        public ShiftType ShiftTime { get; set; }
        public bool IsAvailable { get; set; }
        public Availability(Guid id, DaysOfWeek dayOfWeek, ShiftType shiftTime, bool isAvailable) 
        {
            EmployeeID = id;
            DayOfWeek = dayOfWeek;
            ShiftTime = shiftTime;
            IsAvailable = isAvailable;
        }
        public Availability() { }
    }
}
