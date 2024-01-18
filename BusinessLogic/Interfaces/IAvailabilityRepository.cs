using BusinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAvailabilityRepository
    {
        void AddAvailabilitiesToEmployee(Employee employee);
        void UpdateAvailabilitiesForEmployee(Employee employee);
        void UpdateAvailabilitiesForEmployeeById(Guid id);
        public List<Availability> GetAvailabilitiesByEmployeeId(Guid id);
    }
}
