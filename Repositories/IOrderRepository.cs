using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RIMOrderService.Models;

namespace RIMOrderService.Repositories
{
    public interface IOrderRepository
    {
        string CreateOrder(Order order);
        string UpdateOrderDeliveryAddress(Guid orderId, string newAddress);
        string UpdateOrderItems(Guid orderId, List<OrderItem> newItems);
        string CancelOrder(Guid orderId);
        Order GetOrder(Guid orderId);
        List<Order> GetPagedOrders(int page, int pageSize);
    }
}