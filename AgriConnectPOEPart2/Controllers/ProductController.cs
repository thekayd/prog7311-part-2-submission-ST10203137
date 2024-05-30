using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgriConnectPOEPart2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AgriConnectPOEPart2.Controllers
{
    public class ProductController : Controller
    {
        private readonly YourDbContext _dbContext; // Database context

        public ProductController(YourDbContext dbContext)
        {
            _dbContext = dbContext;  // Initialize the database context
        }

        // Displays the list of products for the authenticated farmer
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            var farmer = _dbContext.Farmers.FirstOrDefault(f => f.Username == username);

            if (farmer == null)
            {
                return Unauthorized();
            }

            var products = _dbContext.Products.Where(p => p.FarmerID == farmer.FarmerID).ToList();
            return View(products); // Return the view with the list of products
        }

        // Displays the form to create a new product
        public IActionResult Create()
        {
            return View();
        }

        // Handles the creation of a new product
        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {

                var username = User.Identity.Name;
                var farmer = await _dbContext.Farmers.FirstOrDefaultAsync(f => f.Username == username);

                if (farmer == null)
                {
                    return Unauthorized();
                }

                model.FarmerID = farmer.FarmerID;
                _dbContext.Products.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(model);
            }

            return View(model);
        }
    }
}
