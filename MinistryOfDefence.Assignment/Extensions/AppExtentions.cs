using Microsoft.EntityFrameworkCore;
using MinistryOfDefence.Assignment.Models;
using MinistryOfDefence.Assignment.Services;

namespace MinistryOfDefence.Assignment.Extensions
{
    public static class AppExtentions
    {
        public static void RegisterDb(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ShoppingDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ShoppingDb"));
            });
        }

        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IShoppingService, ShoppingService>();
        }

        public static async Task SeedDefaultData(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ShoppingDbContext>();
                var logger = scope.ServiceProvider.GetService<ILoggerFactory>();
                if (context is null || logger is null) return;

                await ShoppingDbContextSeeder.SeedDefaultCategoriesAsync(context, logger);
            }
        }
    }
}
