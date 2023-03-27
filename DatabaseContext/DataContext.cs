using Microsoft.EntityFrameworkCore;
using RIMOrderService.Models;

namespace RIMOrderService.DatabaseContext
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderItem>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<OrderItem>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Inventory>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Inventory>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

        }

        public void AddInitialProducts()
        {
            var products = new List<Product>
        {
            new Product { Id = new Guid("537ffa7b-5e07-4245-9d1b-06f4cddf0145"), Name = "Product A", Price = 9.99m },
            new Product { Id = new Guid("1b51985e-a5c1-4ad7-861c-9ee6c3e8d17f"), Name = "Product B", Price = 19.99m },
            new Product { Id = new Guid("93285e94-f748-4ab8-9568-6a228dfedb7a"), Name = "Product C", Price = 29.99m },
            new Product { Id = new Guid("6f51b34c-40f1-43ae-a87c-f5d7c27a7780"), Name = "Product D", Price = 39.99m },
            new Product { Id = new Guid("e5e6ff60-d206-4236-8394-88b3265b581c"), Name = "Product E", Price = 49.99m},
        };

            Products.AddRange(products);
            SaveChanges();

        }

        public void AddInitialInventoryData()
        {
            var inventory = new List<Inventory>
        {
            new Inventory {  ProductId = new Guid("537ffa7b-5e07-4245-9d1b-06f4cddf0145"), Quantity = 10 , WarehouseLocation = "WareHouseA" },
            new Inventory {  ProductId = new Guid("1b51985e-a5c1-4ad7-861c-9ee6c3e8d17f"), Quantity = 6 , WarehouseLocation = "WareHouseB" },
            new Inventory {  ProductId = new Guid("93285e94-f748-4ab8-9568-6a228dfedb7a"), Quantity = 12 , WarehouseLocation = "WareHouseC" },
            new Inventory {  ProductId = new Guid("6f51b34c-40f1-43ae-a87c-f5d7c27a7780"), Quantity = 4 , WarehouseLocation = "WareHouseA" },
            new Inventory {  ProductId = new Guid("e5e6ff60-d206-4236-8394-88b3265b581c"), Quantity = 2 , WarehouseLocation = "WareHouseB"},
        };

            Inventory.AddRange(inventory);
            SaveChanges();

        }

    }
}
