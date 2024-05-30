namespace AgriConnectPOEPart2.Models
{
    // Represents an Employee entity
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }

    // Represents a Farmer entity
    public class Farmer
    {
        public int FarmerID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
