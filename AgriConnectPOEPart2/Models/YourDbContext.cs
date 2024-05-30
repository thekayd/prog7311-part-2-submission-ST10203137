using Microsoft.EntityFrameworkCore;

namespace AgriConnectPOEPart2.Models
{
    // DbContext class for interacting with the database
    public class YourDbContext : DbContext
    {
        private List<IErrorObserver> _errorObservers = new List<IErrorObserver>();
        public YourDbContext(DbContextOptions<YourDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for database tables
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        // Method to attach an error observer
        public void AttachObserver(IErrorObserver observer)
        {
            _errorObservers.Add(observer);
        }

        // Method to notify error observers about an error
        public void NotifyErrorObservers(ErrorViewModel error)
        {
            foreach (var observer in _errorObservers)
            {
                observer.UpdateErrorState(error);
            }
        }
    }
}
