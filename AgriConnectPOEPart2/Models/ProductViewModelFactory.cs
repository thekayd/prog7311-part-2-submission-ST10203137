namespace AgriConnectPOEPart2.Models
{
    // Factory class for creating product view models
    public class ProductViewModelFactory : IProductViewModelFactory
    {
        // Method to create a new product view model instance
        public ProductViewModel CreateProductViewModel(string name, string category, DateTime productionDate)
        {
            
            var productViewModel = new ProductViewModel
            {
                Name = name,
                Category = category,
                ProductionDate = productionDate
            };

            return productViewModel;
        }
    }
}
