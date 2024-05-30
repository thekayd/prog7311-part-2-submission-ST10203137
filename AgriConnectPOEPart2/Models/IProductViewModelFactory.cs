namespace AgriConnectPOEPart2.Models
{
    // Interface for productviewmodel factory
    public interface IProductViewModelFactory
    {
        ProductViewModel CreateProductViewModel(string name, string category, DateTime productionDate);
    }
}
