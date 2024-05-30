namespace AgriConnectPOEPart2.Models
{
    // Interface for product factory
    public interface IProductFactory
    {
        Product CreateProduct(string name, string category, DateTime productionDate, int farmerId);
    }
}
