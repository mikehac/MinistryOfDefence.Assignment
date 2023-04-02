using Microsoft.EntityFrameworkCore;
using MinistryOfDefence.Assignment.Models;
using MinistryOfDefence.Assignment.Services;

namespace MinistryOfDefence.Assignment.Extensions
{
    public static class AppExtentions
    {
        public static void RegisterDb(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ShoppingDbContext>(
            options =>
            {
                options.UseSqlServer(config["ConnectionString:ShoppingDb"]);
            });

        }
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IShoppingService, ShoppingService>();
        }
    }
}
