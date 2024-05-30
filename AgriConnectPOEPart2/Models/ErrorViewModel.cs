using System.Collections.Generic;

namespace AgriConnectPOEPart2.Models
{
    public class ErrorViewModel
    {
        // List of error observers
        private List<IErrorObserver> _observers = new List<IErrorObserver>();

        // Request ID associated with the error
        private string? _requestId;

       
        public string? RequestId
        {
            get => _requestId;
            set
            {
                _requestId = value;
                Notify(); // Notify observers when RequestId is set
            }
        }

        
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Attaches an error observer
        public void Attach(IErrorObserver observer)
        {
            _observers.Add(observer);
        }

        // Detaches an error observer
        public void Detach(IErrorObserver observer)
        {
            _observers.Remove(observer);
        }

        // Notifies all observers
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this); // Update each observer with the error information
            }
        }
    }
}
