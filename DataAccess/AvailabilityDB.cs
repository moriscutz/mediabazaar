using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Interfaces;

namespace DataAccess
{
    public class AvailabilityDB : IAvailabilityDB
    {
        private readonly IAvailabilityRepository availabilityRepository;

        public AvailabilityDB(IAvailabilityRepository availabilityRepository)
        {
            this.availabilityRepository = availabilityRepository;
        }
       public void AddAvailabilitiesToEmployee(Employee employee)
        {
            availabilityRepository.AddAvailabilitiesToEmployee(employee);
        }
       public void UpdateAvailabilitiesForEmployee(Employee employee)
        {
            availabilityRepository.UpdateAvailabilitiesForEmployee(employee);
        }
       public void UpdateAvailabilitiesForEmployeeById(Guid id)
        {
            availabilityRepository.UpdateAvailabilitiesForEmployeeById(id);
        }
        public List<Availability> GetAvailabilitiesByEmployeeId(Guid id) 
        {
             List<Availability> availabilities = new List<Availability>();
            availabilities = availabilityRepository.GetAvailabilitiesByEmployeeId(id);
            return availabilities;
        }
        public List<Employee> GetAvailableEmployeesByDayAndShift(int dayOfWeek, ShiftType shiftType)
        {
            List<Employee> list = new List<Employee>();

            list = availabilityRepository.GetAvailableEmployeesByDayAndShift(dayOfWeek,shiftType);
            return list;
        }
        public List<Employee> GetAvailableEmployeesByDay(int dayOfWeek)
        {
            return availabilityRepository.GetAvailableEmployeesByDay(dayOfWeek);
        }
        public List<Employee> GetAvailableEmployees(DateTime date)
        {
            return availabilityRepository.GetAvailableEmployees(date);
        }
    }
}
