using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RIMOrderService.DatabaseContext;
using RIMOrderService.Services;
using RIMOrderService.Repositories;

namespace RIMOrderService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase(databaseName: "OrderDb"));

            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                context.Database.EnsureCreated();

                // Seed data
                SeedData.Initialize(context);
            }
        }

    }
}
