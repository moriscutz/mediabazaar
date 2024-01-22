using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic.Classes;
using BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MediaBazaarWeb.Pages
{
    [Authorize]
    public class AvailabilitiesModel : PageModel
    {
        private readonly Administration _administration;
        [BindProperty]
        public Dictionary<int, string> SelectedAvailabilities { get; set; }


        public List<SelectListItem> ShiftTypes { get; } = new List<SelectListItem>
        {
        new SelectListItem { Value = "Available", Text = "Available" },
        new SelectListItem { Value = "Not Available", Text = "Not Available" },
        };
        public AvailabilitiesModel(IEmployeeDB employeeDB, IShiftDB shiftDB, IAvailabilityDB availabilityDB)
        {
            _administration = new Administration(employeeDB, shiftDB, availabilityDB);
        }

        public void OnGet()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");
            if (userIdClaim != null)
            {
                Guid userId = new Guid(userIdClaim.Value);
                var existingAvailabilities = _administration.GetAvailabilitiesByEmployeeId(userId);

                SelectedAvailabilities = new Dictionary<int, string>();

                foreach (var availability in existingAvailabilities)
                {
                    
                    int dayIndex = (int)availability.DayOfWeek + 1; 
                    SelectedAvailabilities[dayIndex] = availability.IsAvailable ? "Available" : "Not Available";
                }

                
                for (int day = 1; day <= 7; day++)
                {
                    if (!SelectedAvailabilities.ContainsKey(day))
                    {
                        SelectedAvailabilities[day] = "Not Available"; 
                    }
                }
            }
        }



        public IActionResult OnPost()
        {
            var userIdClaim = HttpContext.User.FindFirst("id");
            if (userIdClaim == null)
            {
                return RedirectToPage("/Index");
            }

            Guid userId = new Guid(userIdClaim.Value);
            var user = _administration.GetEmployeeById(userId);

            
            foreach (var availabilityEntry in SelectedAvailabilities)
            {
                var day = (DaysOfWeek)(availabilityEntry.Key - 1); 
                var isAvailable = availabilityEntry.Value == "Available";

                var availabilityToUpdate = user.Availabilities.FirstOrDefault(a => a.DayOfWeek == day);
                if (availabilityToUpdate != null)
                {
                    availabilityToUpdate.IsAvailable = isAvailable;
                }
                else
                {
                    user.Availabilities.Add(new Availability(userId, day, ShiftType.Morning, isAvailable)); 
                }
            }

            _administration.UpdateEmployee(user); 

            return Page();
        }

    }
}
