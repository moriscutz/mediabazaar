using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IShiftDB
    {
        public void AddShift(Shift shift);
        public void UpdateShift(Shift shift);
        public void DeleteShift(Shift shift);
        public Shift GetShiftById(Guid shiftId);
        public List<Shift> GetAllShifts();
        public List<Shift> GetShiftsForEmployeeById(Guid employeeId);
        public List<Preference> GetPreferencesByEmployeeId(Guid employeeId);
        public List<Preference> GetPreferencesByDayOfWeek(int dayOfWeek);

        public void AddPreference(Preference preference);
        public void UpdatePreference(Preference preference);
    }
}
