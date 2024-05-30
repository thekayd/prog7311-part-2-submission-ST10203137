using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AgriConnectPOEPart2.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgriConnectPOEPart2.Controllers
{
    [Authorize] // Requires authorization for accessing any action in this controller
    public class ProductsController : Controller
    {
        private readonly YourDbContext _context;
        private readonly IProductFactory _productFactory;
        private readonly IProductViewModelFactory _productViewModelFactory;

        public ProductsController(YourDbContext context, IProductFactory productFactory, IProductViewModelFactory productViewModelFactory)
        {
            _context = context;
            _productFactory = productFactory;
            _productViewModelFactory = productViewModelFactory;
        }

        // Displays the list of products for the authenticated farmer
        public IActionResult Index()
        {
            var farmerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var products = _context.Products.Where(p => p.FarmerID == farmerId).ToList();
            return View(products);
        }

        // Displays the form to create a new product
        public IActionResult Create()
        {
            return View();
        }

        // Handles the creation of a new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var farmerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                // Uses the Product Factory to create a Product
                var product = _productFactory.CreateProduct(model.Name, model.Category, model.ProductionDate, farmerId);

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
