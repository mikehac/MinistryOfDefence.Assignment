namespace MinistryOfDefence.Assignment.Models
{
    public class ShoppingDbContextSeeder
    {
        public static async Task SeedDefaultCategoriesAsync(ShoppingDbContext dbContext, ILoggerFactory loggerFactory)
        {
            if (dbContext.Categories.Any())
                return;

            try
            {
                var categories = new List<Category>
                {
                    new Category {
                        Name = "Cleaning",
                        NameHeb="מוצרי ניקיון"
                    },
                    new Category {
                        Name = "Cheeses",
                        NameHeb="גבינות"
                    },
                    new Category {
                        Name = "Vegetables and fruits",
                        NameHeb="ירקות ופירות"
                    },
                    new Category {
                        Name = "Meat and fish",
                        NameHeb="בשר ודגים"
                    },
                    new Category {
                        Name = "Pastries",
                        NameHeb="מאפים"
                    },
                };
                await dbContext.Categories.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<ShoppingDbContext>();
                log.LogError(ex.Message);
            }
        }
    }
}
