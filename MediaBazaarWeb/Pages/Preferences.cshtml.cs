using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic.Classes;
using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLogic.Interfaces;

namespace MediaBazaarWeb.Pages
{
    public class PreferencesModel : PageModel
    {
        private readonly Administration _administration;
        [BindProperty]
        public Dictionary<int, ShiftType> SelectedPreferences { get; set; }

        public List<SelectListItem> ShiftTypes { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Morning", Text = "Morning" },
        new SelectListItem { Value = "Afternoon", Text = "Afternoon" },
        new SelectListItem { Value = "Night", Text = "Night" }
    };
        public PreferencesModel(IEmployeeDB employeeDB, IShiftDB shiftDB)
        {
            _administration = new Administration(employeeDB, shiftDB);
        }

        public void OnGet()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");
            if (userIdClaim != null)
            {
                Guid userId = new Guid(userIdClaim.Value);

                // Retrieve existing preferences for the user
                var existingPreferences = _administration.GetPreferencesByEmployeeId(userId);

                // Initialize SelectedPreferences dictionary and populate it with existing preferences
                SelectedPreferences = new Dictionary<int, ShiftType>
            {
                { 1, GetShiftTypeForDay(existingPreferences, 1) },
                { 2, GetShiftTypeForDay(existingPreferences, 2) },
                { 3, GetShiftTypeForDay(existingPreferences, 3) },
                { 4, GetShiftTypeForDay(existingPreferences, 4) },
                { 5, GetShiftTypeForDay(existingPreferences, 5) },
                { 6, GetShiftTypeForDay(existingPreferences, 6) },
                { 7, GetShiftTypeForDay(existingPreferences, 7) }
            };
            }
        }

        private ShiftType GetShiftTypeForDay(List<Preference> existingPreferences, int dayOfWeek)
        {
            var existingPreference = existingPreferences.FirstOrDefault(p => p.DayOfWeek == dayOfWeek);
            return existingPreference?.ShiftType ?? ShiftType.Morning;
        }

        public IActionResult OnPost()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");
            if (userIdClaim == null)
            {
                return RedirectToPage("/Index");
            }

            Guid userId = new Guid(userIdClaim.Value);

            if (SelectedPreferences == null)
            {
                return Page();
            }

            bool hasError = false;
            var user = _administration.GetEmployeeById(userId);
            var existingPreferences = _administration.GetPreferencesByEmployeeId(userId);

            foreach (var kvp in SelectedPreferences)
            {
                //kvp-keyvaluepair
                int dayOfWeek = kvp.Key;
                ShiftType shiftType = kvp.Value;

                // Convert day of week to date
                DateTime shiftDate = ConvertDayOfWeekToDate(dayOfWeek);

                // Check if the shift is available
                if (!_administration.IsShiftAvailable(shiftDate, shiftType))
                {
                    ModelState.AddModelError("", $"Cannot add shift on {shiftDate:yyyy-MM-dd} for {shiftType} as the shift limit has been reached.");
                    hasError = true;
                    continue;
                }

                var existingPreference = existingPreferences.FirstOrDefault(p => p.DayOfWeek == dayOfWeek);

                if (existingPreference != null)
                {
                    existingPreference.ShiftType = shiftType;
                    _administration.UpdatePreference(existingPreference);
                }
                else
                {
                    var newPreference = new Preference
                    {
                        PreferenceId = Guid.NewGuid(),
                        DayOfWeek = dayOfWeek,
                        ShiftType = shiftType,
                        EmployeeId = userId
                    };
                    _administration.AddPreference(newPreference);
                }
            }

            if (!hasError)
            {
                // Trigger the scheduling process
                _administration.ScheduleShiftsBasedOnPreferences();
                return RedirectToPage("/Schedule");
            }

            return Page();

        }
        private DateTime ConvertDayOfWeekToDate(int dayOfWeek)
        {
            // Assuming dayOfWeek is 1 for Monday, 2 for Tuesday, ..., 7 for Sunday
            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;

            // Adjust for Sunday being 0 in DayOfWeek
            currentDayOfWeek = currentDayOfWeek == 0 ? 7 : currentDayOfWeek;

            int daysUntilNextDayOfWeek = dayOfWeek - currentDayOfWeek;
            if (daysUntilNextDayOfWeek < 0)
            {
                // If the day has already passed in the current week, find the next occurrence in the next week
                daysUntilNextDayOfWeek += 7;
            }

            DateTime nextDayOfWeek = today.AddDays(daysUntilNextDayOfWeek);
            return nextDayOfWeek;
        }

    }

}
