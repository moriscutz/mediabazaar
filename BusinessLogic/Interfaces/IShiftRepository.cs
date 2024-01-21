using BusinessLogic.Classes;
using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IShiftRepository
    {
        int CountShiftsOnDateAndType(DateTime date, ShiftType shiftType);
        public void AddShift(Shift shift);
        public void UpdateShift(Shift shift);
        public void DeleteShift(Shift shift);
        public Shift GetShiftById(Guid shiftId);
        public List<Shift> GetAllShifts();
        public List<Shift> GetShiftsForEmployeeById(Guid employeeId);
        public void DeleteAllShifts();
        public Shift GetShiftByDateAndType(DateTime date, ShiftType shiftType);
        public List<Shift> GetShiftsByDateAndType(DateTime date, ShiftType shiftType);
        public List<Shift> GetShiftsByDate(DateTime date);
    }
}
