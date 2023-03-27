using Microsoft.EntityFrameworkCore;
using RIMOrderService.DatabaseContext;
using RIMOrderService.Models;

namespace RIMOrderService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }

        public List<Product> GetProducts()
        {
            return _dbContext.Products.Include(o => o.Inventories).ToList();
        }

        public Product GetProduct(Guid id)
        {
            return _dbContext.Products.Include(o => o.Inventories).Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Inventory> GetInventoryList()
        {
            return _dbContext.Inventory.ToList();
        }

    }
}
