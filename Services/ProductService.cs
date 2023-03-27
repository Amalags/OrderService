using RIMOrderService.Models;
using RIMOrderService.Repositories;

namespace RIMOrderService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Guid CreateProduct(Product product)
        {
            product.Id = new Guid();
            return _productRepository.CreateProduct(product);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.GetProduct(id);
        }

        public List<Inventory> GetInventoryList()
        {
            return _productRepository.GetInventoryList();
        }
    }
}
