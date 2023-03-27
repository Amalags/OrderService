using RIMOrderService.Models;

namespace RIMOrderService.Services
{
    public interface IOrderService
    {
        string CreateOrder(Order order);
        string UpdateDeliveryAddress(Guid orderId, string newAddress);
        string UpdateOrderItems(Guid orderId, List<OrderItem> newItems);
        string CancelOrder(Guid orderId);
        Order GetOrder(Guid orderId);
        List<Order> GetPagedOrders(int page, int pageSize);
    }
}
