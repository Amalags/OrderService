using RIMOrderService.Models;

namespace RIMOrderService.Services
{
    public interface IProductService
    {
        Guid CreateProduct(Product product);
        List<Product> GetProducts();
        Product GetProduct(Guid id);
        List<Inventory> GetInventoryList();
    }
}
