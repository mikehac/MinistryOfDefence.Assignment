using MinistryOfDefence.Assignment.DTOs;
using MinistryOfDefence.Assignment.Models;

namespace MinistryOfDefence.Assignment.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly ShoppingDbContext _dbContext;

        public ShoppingService(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddNewItem(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = _dbContext.Categories;
            return null;
        }

        public IEnumerable<ItemDTO> GetItemsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
