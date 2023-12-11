using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class Preference
    {
        public Guid PreferenceId { get; set; }
        public int DayOfWeek { get; set; }
        public ShiftType ShiftType { get; set; }
        public Guid EmployeeId { get; set; }

        public Preference(Guid preferenceId, int dayOfWeek, ShiftType shiftType, Guid employeeId)
        {
            PreferenceId = preferenceId;
            DayOfWeek = dayOfWeek;
            ShiftType = shiftType;
            EmployeeId = employeeId;
        }

        public Preference() { }
    }
}
