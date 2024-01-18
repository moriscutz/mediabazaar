using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Enums;
namespace BusinessLogic.Classes
{
    public class Employee
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position JobPosition { get; set; } 
        public List<Shift> Shifts { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public List<Availability> Availabilities { get; set; } = new List<Availability>();
        public Employee(Guid id, string firstName, string lastName, Position jobPosition, string password, string username)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.JobPosition = jobPosition;
            this.Shifts = new List<Shift>();
            Password = password;
            Username = username;
            this.Availabilities = new List<Availability>();
        }
        public Employee() { }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
