using System.Text.Json.Serialization;

namespace RIMOrderService.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string WarehouseLocation { get; set; }
    }
}
