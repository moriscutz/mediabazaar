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


        public List<DayStatus> TwoWeeksSchedule { get; set; }

        public ScheduleModel(IEmployeeDB employeeDB, IShiftDB shiftDB, ILogger<ScheduleModel> logger)
        {
            _administration = new Administration(employeeDB, shiftDB);
            TwoWeeksSchedule = new List<DayStatus>();
            _logger = logger;
        }
        public Employee CurrentEmployee { get; set; }
        public void OnGet(string view)
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
            int numberOfWeeks = view == "one-week" ? 1 : 2;
            InitializeSchedule(numberOfWeeks);
            PopulateShiftsForEmployee(CurrentEmployee.ID);
        }

        private void InitializeSchedule(int numberOfWeeks)
        {
            var currentDate = DateTime.Today;
            // Find the previous Monday or today if today is Monday
            var startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday);
            if (startDate > currentDate)
            {
                startDate = startDate.AddDays(-7); 
            }

            TwoWeeksSchedule.Clear();

            for (int i = 0; i < numberOfWeeks * 7; i++)
            {
                var currentScheduleDate = startDate.AddDays(i);
                TwoWeeksSchedule.Add(new DayStatus
                {
                    Date = currentScheduleDate,
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