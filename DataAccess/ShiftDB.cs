using BusinessLogic.Classes;
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
        public Shift GetShiftById(int shiftId)
        {
            return shiftRepository.GetShiftById(shiftId);
        }
        public List<Shift> GetAllShifts()
        {
            return shiftRepository.GetAllShifts();
        }
    }
}
