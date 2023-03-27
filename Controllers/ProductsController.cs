using Microsoft.AspNetCore.Mvc;
using RIMOrderService.Models;
using RIMOrderService.Services;

namespace RIMOrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var message = string.Empty;
            try
            {
                var createdProductId = _productService.CreateProduct(product);
                message = $"Product {createdProductId} is created";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok(message);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = _productService.GetProducts();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            Product product = new Product();
            try
            {
                product = _productService.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(product);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IProductService _productService;

        public InventoryController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetInventoryList()
        {
            List<Inventory> inventoryList = new List<Inventory>();
            try
            {
                inventoryList = _productService.GetInventoryList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok(inventoryList);
        }
    }
}
