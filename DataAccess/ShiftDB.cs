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
        public List<Preference> GetPreferencesByEmployeeId(Guid employeeId)
        {
            return shiftRepository.GetPreferencesByEmployeeId(employeeId);
        }
        public List<Preference> GetPreferencesByDayOfWeek(int dayOfWeek)
        {
            return shiftRepository.GetPreferencesByDayOfWeek(dayOfWeek);
        }
        public void AddPreference(Preference preference)
        {
            shiftRepository.AddPreference(preference);
        }
        public void UpdatePreference(Preference preference)
        {
            shiftRepository.UpdatePreference(preference);
        }

        
    }
}
