namespace AgriConnectPOEPart2.Models
{
    // Factory class for creating products
    public class ProductFactory : IProductFactory
    {
        private readonly YourDbContext _context;

        // Constructor to inject the database context
        public ProductFactory(YourDbContext context)
        {
            _context = context;
        }

        // Method to create a new product instance
        public Product CreateProduct(string name, string category, DateTime productionDate, int farmerId)
        {
            // Creates a new product object with the provided data
            var product = new Product
            {
                Name = name,
                Category = category,
                ProductionDate = productionDate,
                FarmerID = farmerId
            };

            return product;
        }
    }
}
