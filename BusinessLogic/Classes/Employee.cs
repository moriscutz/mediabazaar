﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Enums;
namespace BusinessLogic.Classes
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position JobPosition { get; set; } 
        public List<Shift> Shifts { get; set; }
        public Department Department { get; set; } 
        public string Password { get; set; }
        public Employee(int id, string firstName, string lastName, Position jobPosition, Department department, string password)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.JobPosition = jobPosition;
            this.Shifts = new List<Shift>();
            this.Department = department;
            Password = password;
        }
        public Employee() { }
    }
}