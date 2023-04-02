using MinistryOfDefence.Assignment.Services;

namespace MinistryOfDefence.Assignment.Extensions
{
    public static class AppExtentions
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IShoppingService, ShoppingService>();
        }
    }
}
