using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MediaBazaarWeb.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;
        private readonly Administration administration;
        public IndexModel(ILogger<IndexModel> logger, IEmployeeDB employeeDB, IShiftDB shiftDB, IAvailabilityDB availabilityDB)
        {
            _logger = logger;
            administration = new Administration(employeeDB, shiftDB, availabilityDB);
        }
        [BindProperty]
        public LoginDTO loginDto { get; set; }
        public Employee CurrentEmployee { get; set; }
        public IActionResult OnGet()
        {
            _logger.LogInformation("ONGET WAS CALLED");
            if (User.Identity.IsAuthenticated)
            {
                _logger.LogInformation("User was not authenticated");
                return RedirectToPage("/Schedule");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            _logger.LogInformation("ONPOST WAS CALLED");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is Valid");
                _logger.LogInformation("Trying to authenticate the user");
                var user = administration.Authenticate(loginDto.Username, loginDto.Password);

                if (user == null)
                {
                    _logger.LogInformation("User was null");
                    ModelState.AddModelError("", "The user was not found");
                    TempData["CredentialsWrong"]="The username or the password do not match the credentials in our database.";
                    return Page();
                }
                else
                {

                    CurrentEmployee = user;


                    _logger.LogInformation("User was not null, authenticating in");
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, CurrentEmployee.ID.ToString()));
                    claims.Add(new Claim("id", CurrentEmployee.ID.ToString()));
                    _logger.LogInformation($"ClaimTypes.NameIdentifier: {CurrentEmployee.ID}");
                    _logger.LogInformation($"Custom claim 'id': {CurrentEmployee.ID}");

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                    HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                    _logger.LogInformation("User authenticated successfully.");
                    return RedirectToPage("/Schedule");
                }
            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];

                    foreach (var error in state.Errors)
                    {
                        _logger.LogError($"Error in ModelState for key '{key}': {error.ErrorMessage}");

                        
                        if (error.Exception != null)
                        {
                            _logger.LogError(error.Exception, "Exception in ModelState");
                        }
                    }
                }
                _logger.LogInformation("ModelState was invalid");
                return Page();
            }
        }
    }
}



