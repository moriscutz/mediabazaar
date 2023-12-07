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
        public IndexModel(ILogger<IndexModel> logger, IEmployeeDB employeeDB, IShiftDB shiftDB)
        {
            _logger = logger;
            administration = new Administration(employeeDB, shiftDB);
        }
        [BindProperty]
        public Employee CurrentEmployee { get; set; }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Schedule");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = administration.Authenticate(CurrentEmployee.ID, CurrentEmployee.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "The user was not found");
                    TempData["CredentialsWrong"]="The id or the password is wrong";
                    return Page();
                }
                else
                {
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
                _logger.LogInformation("ModelState was invalid");
                return Page();
            }
        }
    }
}



