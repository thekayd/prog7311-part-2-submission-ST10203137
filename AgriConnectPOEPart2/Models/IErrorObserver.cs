namespace AgriConnectPOEPart2.Models
{
    // Interface for error observers
    public interface IErrorObserver
    {
        // Method to update observers with error information
        void Update(ErrorViewModel error);

        // Method to update error state
        void UpdateErrorState(ErrorViewModel error);
    }
}
