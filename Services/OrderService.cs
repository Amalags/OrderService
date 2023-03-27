using RIMOrderService.Models;
using RIMOrderService.Repositories;

namespace RIMOrderService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public string CreateOrder(Order order)
        {
            return _orderRepository.CreateOrder(order);

        }
        public string UpdateDeliveryAddress(Guid orderId, string newAddress)
        {
            return _orderRepository.UpdateOrderDeliveryAddress(orderId, newAddress);

        }

        public string UpdateOrderItems(Guid orderId, List<OrderItem> newItems)
        {
            return _orderRepository.UpdateOrderItems(orderId,newItems);
        }

        public string CancelOrder(Guid orderId)
        {
            return _orderRepository.CancelOrder(orderId);
        }

        public Order GetOrder(Guid orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        public List<Order> GetPagedOrders(int page, int pageSize)
        {
            return _orderRepository.GetPagedOrders(page, pageSize);
        }
    }
}
