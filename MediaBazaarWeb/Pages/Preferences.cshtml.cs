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
            SelectedPreferences = new Dictionary<int, ShiftType>
        {
            { 1, ShiftType.Morning },  
            { 2, ShiftType.Morning },  
            { 3, ShiftType.Morning },  
            { 4, ShiftType.Morning },  
            { 5, ShiftType.Morning },  
            { 6, ShiftType.Morning },  
            { 7, ShiftType.Morning }   
        };
        }

        public IActionResult OnPost()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");
            if (userIdClaim != null)
            {
                Guid userId = new Guid(userIdClaim.Value);

                foreach (var kvp in SelectedPreferences)
                {
                    int dayOfWeek = kvp.Key;
                    ShiftType shiftType = kvp.Value;

                    // Get the user
                    var user = _administration.GetEmployeeById(userId);

                    // Find the existing preference for the specified day
                    var existingPreference = user.Preferences.FirstOrDefault(p => p.DayOfWeek == dayOfWeek);

                    if (existingPreference != null)
                    {
                        // Update existing preference
                        existingPreference.ShiftType = shiftType;
                        _administration.UpdatePreference(existingPreference);
                    }
                    else
                    {
                        // Add new preference
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

                // Redirect to Schedule page after saving preferences
                return RedirectToPage("/Schedule");
            }

            // Handle the case where the user is not authenticated
            return RedirectToPage("/Index");
        }





        private DateTime FindNextDayOfWeek(DateTime date, DayOfWeek dayOfWeek)
        {
            int daysToAdd = ((int)dayOfWeek - (int)date.DayOfWeek + 7) % 7;
            return daysToAdd == 0 ? date.AddDays(7) : date.AddDays(daysToAdd);
        }
    }
}
