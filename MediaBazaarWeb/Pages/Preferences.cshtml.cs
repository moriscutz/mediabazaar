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
            if (userIdClaim != null)
            {
                Guid userId = new Guid(userIdClaim.Value);

                if (SelectedPreferences != null)
                {
                    var user = _administration.GetEmployeeById(userId);
                    var existingPreferences = _administration.GetPreferencesByEmployeeId(userId);

                    foreach (var kvp in SelectedPreferences)
                    {
                        int dayOfWeek = kvp.Key;
                        ShiftType shiftType = kvp.Value;

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

                    return RedirectToPage("/Schedule");
                }
            }

            return RedirectToPage("/Index");
        }
    }

}
