// Models/ErrorObserver.cs
// This class implements the IErrorObserver interface and provides methods to update error information.
//using System;

namespace AgriConnectPOEPart2.Models
{
    public class ErrorObserver : IErrorObserver
    {
        // Updates the error information
        public void Update(ErrorViewModel error)
        {
            throw new NotImplementedException();
        }

        // Updates the error state
        public void UpdateErrorState(ErrorViewModel error)
        {
            // Handle error state change here
            Console.WriteLine($"Error state changed. RequestId: {error.RequestId}");
        }
    }
}
