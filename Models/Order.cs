using System.Text.Json.Serialization;

namespace RIMOrderService.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItem> Items { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public DateTime OrderUpdatedDate { get; set; }

    }
}