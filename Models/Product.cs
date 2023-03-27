using System.Text.Json.Serialization;

namespace RIMOrderService.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public List<Inventory> Inventories { get; set; }
    }
}
