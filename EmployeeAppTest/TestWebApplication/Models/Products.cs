namespace TestWebApplication.Models
{
    public class Products
    {
        public long ProductID { get; set; }
        public string? Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
