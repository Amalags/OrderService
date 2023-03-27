using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RIMOrderService.DatabaseContext;
using RIMOrderService.Models;

namespace RIMOrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _orderDbContext;

        public OrderRepository(DataContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public string CreateOrder(Order order)
        {
            var id = new Guid();
            foreach (var item in order.Items)
            {
                var inventoryData = _orderDbContext.Inventory.FirstOrDefault(i => i.ProductId == item.ProductId);
                if(inventoryData == null)
                {
                    return $"Requested product {item.ProductId} is not valid";
                }
                else if(item.Quantity > inventoryData.Quantity)
                {
                    return $"Requested Quantity for the item {item.ProductId} is not available";
                }
                else
                {
                    inventoryData.Quantity -= item.Quantity;
                }

            }
            order.OrderId = id;
            _orderDbContext.Orders.Add(order);
            _orderDbContext.SaveChanges();
            return String.Empty;
        }

        public string UpdateOrderDeliveryAddress(Guid orderId, string newAddress)
        {
            var order =  _orderDbContext.Orders.Find(orderId);
            if (order != null)
            {
                order.DeliveryAddress = newAddress;
                _orderDbContext.SaveChanges();
                return String.Empty; 
            }
            else
                return "Order Not Found";
        }

        public string UpdateOrderItems(Guid orderId, List<OrderItem> newItems)
        {
            foreach (var item in newItems)
            {
                var inventoryData = _orderDbContext.Inventory.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (inventoryData == null)
                {
                    return $"Requested product {item.ProductId} is not valid";
                }
                else if (item.Quantity > inventoryData.Quantity)
                {
                    return $"Requested Quantity for the item {item.ProductId} is not available";
                }
                else
                {
                    inventoryData.Quantity -= item.Quantity;
                }
            }
            var order = _orderDbContext.Orders.Include(o => o.Items).FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                order.Items = newItems;
                _orderDbContext.SaveChanges();
                return String.Empty;
            }
            else
                return "Order Not Found";

        }

        public string CancelOrder(Guid orderId)
        {
            var order = _orderDbContext.Orders.Find(orderId);
            if (order != null)
            {
                order.IsCanceled = true;
                _orderDbContext.SaveChanges();
                return String.Empty;
            }
            else
                return "Order Not Found";
        }

        public Order GetOrder(Guid orderId)
        {
            return _orderDbContext.Orders.Include(o => o.Items).Where(o => o.OrderId == orderId).FirstOrDefault();
        }

        public List<Order> GetPagedOrders(int page, int pageSize)
        {
            return _orderDbContext.Orders.Include(o => o.Items).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}