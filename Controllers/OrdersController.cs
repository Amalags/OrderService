using Microsoft.AspNetCore.Mvc;
using RIMOrderService.Models;
using RIMOrderService.Services;

namespace RIMOrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order newOrder)
        {
            var message = string.Empty;
            try
            {
                message = _orderService.CreateOrder(newOrder);
                if (!String.IsNullOrEmpty(message))
                {
                    return BadRequest(message);
                }
                message = "Order created successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(message);
        }

        [HttpPut("{orderId}/deliveryAddress")]
        public IActionResult UpdateDeliveryAddress(Guid orderId, [FromBody] string newAddress)
        {
            var message = "";
            try
            {
                message = _orderService.UpdateDeliveryAddress(orderId, newAddress);
                if (!String.IsNullOrEmpty(message))
                {
                    return BadRequest(message);
                }
                message = $"Delivery address of the order {orderId} is updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(message);
        }

        [HttpPut("{orderId}/items")]
        public IActionResult UpdateOrderItems(Guid orderId, [FromBody] List<OrderItem> newItems)
        {
            var message = string.Empty;
            try
            {
                message = _orderService.UpdateOrderItems(orderId, newItems);
                if (!String.IsNullOrEmpty(message))
                {
                    return BadRequest(message);
                }
                message = $"Items of the order {orderId} is updated";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(message);
        }

        [HttpPut("{orderId}")]
        public IActionResult CancelOrder(Guid orderId)
        {
            var message = string.Empty;
            try
            {
                message = _orderService.CancelOrder(orderId);
                if (!String.IsNullOrEmpty(message))
                {
                    return BadRequest(message);
                }
                message = $"Order {orderId} is cancelled";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(message);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrder(Guid orderId)
        {
            Order order = new Order();
            try
            {
                order = _orderService.GetOrder(orderId);
                if (order == null)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex; 
            }

            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetPagedOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            List<Order> orders = new List<Order>();
            try
            {
                orders = _orderService.GetPagedOrders(page, pageSize);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(orders);
        }
    }
}