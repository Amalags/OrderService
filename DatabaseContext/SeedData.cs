using Microsoft.EntityFrameworkCore;

namespace RIMOrderService.DatabaseContext
{
    public static class SeedData
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;  
            }

            context.AddInitialProducts();

            if (context.Inventory.Any())
            {
                return;
            }

            context.AddInitialInventoryData();
        }
    }
}
