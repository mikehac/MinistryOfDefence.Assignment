using MinistryOfDefence.Assignment.DTOs;

namespace MinistryOfDefence.Assignment.Services
{
    public interface IShoppingService
    {
        IEnumerable<CategoryDTO> GetCategories();
        IEnumerable<ItemDTO> GetItemsByCategory(int categoryId);
        Task AddNewItem(ItemDTO itemDTO);
    }
}
