using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using MediaBazaarWeb.Pages.Shared;

namespace MediaBazaarWeb.Pages
{
    public class ScheduleModel : PageModel
    {
        private readonly Administration _administration;
        private readonly ILogger<ScheduleModel> _logger;    
        //private readonly string _defaultEmployeeId = "1"; // Replace with logged-in user ID later

        public List<DayStatus> TwoWeeksSchedule { get; set; }

        public ScheduleModel(IEmployeeDB employeeDB, IShiftDB shiftDB, ILogger<ScheduleModel> logger)
        {
            _administration = new Administration(employeeDB, shiftDB);
            TwoWeeksSchedule = new List<DayStatus>();
            _logger = logger;
        }
        public Employee CurrentEmployee { get; set; }
        public void OnGet()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");
            if (userIdClaim != null)
            {
                
                Guid userId = new Guid(userIdClaim.Value);
                CurrentEmployee = _administration.GetEmployeeById(userId);
                _logger.LogInformation($"User authenticated. CurrentEmployee ID: {CurrentEmployee?.ID}");
            }
            else
            {
                ModelState.AddModelError("", "There has been an error with the authentication");
                RedirectToPage("Index", new { message = "You are not logged in. Please log in to access this page." });


            }
            InitializeTwoWeeksSchedule();
            PopulateShiftsForEmployee(CurrentEmployee.ID);
        }

        private void InitializeTwoWeeksSchedule()
        {
            var startDate = FindNextMonday(DateTime.Today);
            TwoWeeksSchedule.Clear();

            for (int i = 0; i < 14; i++) // 2 weeks
            {
                var currentDate = startDate.AddDays(i);
                TwoWeeksSchedule.Add(new DayStatus
                {
                    Date = currentDate,
                    Shifts = new List<Shift>() 
                });
            }
        }

        private DateTime FindNextMonday(DateTime date)
        {
            int daysToAdd = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
            return daysToAdd == 0 ? date.AddDays(7) : date.AddDays(daysToAdd);
        }

        private void PopulateShiftsForEmployee(Guid employeeId)
        {
            _logger.LogInformation($"Populating shifts for employee ID: {employeeId}...");

            // Use the new method to get shifts for the employee by ID
            var employeeShifts = _administration.GetShiftsForEmployeeById(employeeId);

            foreach (var dayStatus in TwoWeeksSchedule)
            {
                var shiftsForDay = employeeShifts.Where(s => s.Date.Date == dayStatus.Date.Date).ToList();
                dayStatus.Shifts = shiftsForDay;
                dayStatus.IsFull = shiftsForDay.Count >= 2;
            }
        }
    }
    public class DayStatus
    {
        public DateTime Date { get; set; }
        public bool IsFull { get; set; }
        public List<Shift> Shifts { get; set; }

        public string GetShiftSummary()
        {
            if (!Shifts.Any())
            {
                return "No shifts";
            }

            var shiftSummary = Shifts.GroupBy(s => s.Type)
                                     .Select(g => $"{g.Key}: {g.Count()} shifts")
                                     .Aggregate((current, next) => current + ", " + next);

            return shiftSummary;
        }

    }
}

