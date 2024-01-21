using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ShiftDB : IShiftDB
    {
        private readonly IShiftRepository shiftRepository;

        public ShiftDB(IShiftRepository shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }
        public int CountShiftsOnDateAndType(DateTime date, ShiftType shiftType)
        {
            return shiftRepository.CountShiftsOnDateAndType(date, shiftType);
        }

        public void AddShift(Shift shift)
        {
            shiftRepository.AddShift(shift);
        }
        public void UpdateShift(Shift shift)
        {
            shiftRepository.UpdateShift(shift);
        }
        public void DeleteShift(Shift shift)
        {
            shiftRepository.DeleteShift(shift);
        }
        public Shift GetShiftById(Guid shiftId)
        {
            return shiftRepository.GetShiftById(shiftId);
        }
        public List<Shift> GetAllShifts()
        {
            return shiftRepository.GetAllShifts();
        }

        public List<Shift> GetShiftsForEmployeeById(Guid employeeId)
        {
            return shiftRepository.GetShiftsForEmployeeById(employeeId);
        }
        public void DeleteAllShifts()
        {
            shiftRepository.DeleteAllShifts();
        }
        public Shift GetShiftByDateAndType(DateTime date, ShiftType shiftType)
        {
            return shiftRepository.GetShiftByDateAndType(date, shiftType);
        }
        public List<Shift> GetShiftsByDateAndType(DateTime date, ShiftType shiftType)
        {
            return shiftRepository.GetShiftsByDateAndType(date, shiftType);
        }
        public List<Shift> GetShiftsByDate(DateTime date)
        {
            return shiftRepository.GetShiftsByDate(date);
        }
    }
}
