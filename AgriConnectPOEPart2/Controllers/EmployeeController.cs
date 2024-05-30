using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgriConnectPOEPart2.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgriConnectPOEPart2.Controllers
{
    // Restricts access to users with the "Employee" role
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly YourDbContext _context;

        public EmployeeController(YourDbContext context)
        {
            _context = context;
        }

        // GET: AddFarmer view
        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Protects against Cross-Site Request Forgery (CSRF) attacks
        public async Task<IActionResult> AddFarmer(FarmerViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Creates a new Farmer object with data from the form
                var farmer = new Farmer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email
                };

                // Adds the farmer to the database and save changes
                _context.Farmers.Add(farmer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(FarmersList));
            }
            return View(model);
        }

        public IActionResult FarmersList()
        {
            // Retrieves all farmers from the database and pass them to the view
            var farmers = _context.Farmers.ToList();
            return View(farmers);
        }


        public IActionResult FarmerDetails(int id)
        {
            // Find the farmer with the specified id
            var farmer = _context.Farmers.FirstOrDefault(f => f.FarmerID == id);
            if (farmer == null)
            {
                return NotFound();
            }

            // Retrieves products associated with the farmer
            var products = _context.Products.Where(p => p.FarmerID == farmer.FarmerID).ToList();

            // Passes farmer and products to the view using ViewBag
            ViewBag.Farmer = farmer;
            ViewBag.Products = products;

            return View();
        }


        public IActionResult ProductsByFarmer()
        {
            // Retrieves all farmers and pass them to the view
            ViewBag.Farmers = _context.Farmers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult ProductsByFarmer(int farmerId, DateTime? startDate, DateTime? endDate, string productType)
        {
            IQueryable<Product> query = _context.Products;

            // Filters products based on selected criteria
            // If not "All Farmers"
            if (farmerId != -1)
            {
                query = query.Where(p => p.FarmerID == farmerId);
            }

            if (startDate != null && endDate != null)
            {
                query = query.Where(p => p.ProductionDate >= startDate && p.ProductionDate <= endDate);
            }

            if (!string.IsNullOrEmpty(productType))
            {
                query = query.Where(p => p.Category == productType);
            }

            var products = query.ToList();

            ViewBag.Farmers = _context.Farmers.ToList();
            ViewBag.SelectedFarmerId = farmerId;
            return View(products);
        }
    }
}
