namespace AgriConnectPOEPart2.Models
{
    // Represents an Product entity
    public class Product
    {
        public int ProductID { get; set; }
        public int FarmerID { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public DateTime ProductionDate { get; set; }
        public Farmer Farmer { get; set; }
    }

    // Represents an ProductViewModel entity
    public class ProductViewModel
        {
            public string? Name { get; set; }
            public string? Category { get; set; }
            public DateTime ProductionDate { get; set; }

            public int SelectedFarmerId { get; set; }
        }
   

}
