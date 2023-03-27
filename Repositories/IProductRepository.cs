using RIMOrderService.Models;

namespace RIMOrderService.Repositories
{
    public interface IProductRepository
    {
        Guid CreateProduct(Product product);
        List<Product> GetProducts();
        Product GetProduct(Guid id);
        List<Inventory> GetInventoryList();
    }
}
