using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RIMOrderService.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
