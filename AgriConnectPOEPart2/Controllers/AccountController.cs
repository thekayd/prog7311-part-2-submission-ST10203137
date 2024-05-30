using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using AgriConnectPOEPart2.Models;

namespace AgriConnectPOEPart2.Controllers
{
    public class AccountController : Controller
    {
        private readonly YourDbContext _dbContext; //DbContext

        public AccountController(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        // POST: Login action
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the entered credentials match a farmer and employee record
                var farmer = _dbContext.Farmers.SingleOrDefault(f => f.Username == model.Username && f.Password == model.Password);
                var employee = _dbContext.Employees.SingleOrDefault(e => e.Username == model.Username && e.Password == model.Password);

                if (farmer != null)
                {
                    // Sign in the farmer user
                    await SignInUser(farmer.Username, "Farmer", farmer.FarmerID);
                    return RedirectToAction("Index", "Products"); // Redirect to farmer dashboard after successful login
                }
                else if (employee != null)
                {
                    // Sign in the employee user
                    await SignInUser(employee.Username, "Employee", employee.EmployeeID);
                    return RedirectToAction("FarmersList", "Employee"); // Redirect to employee dashboard after successful login
                }
            }

            // If invalid credentials, add error message and return the login view
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        // Method to sign in a user
        private async Task SignInUser(string username, string role, int userId)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
