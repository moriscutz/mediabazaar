using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
        public ShiftType Type { get; set; } 
        public int EmployeeID { get; set; }

        public Shift(int shiftId, DateTime date, ShiftType type, int employeeID)
        {
            ShiftId = shiftId;
            this.Date = date;
            this.Type = type;
            this.EmployeeID = employeeID;
        }
    }
}
