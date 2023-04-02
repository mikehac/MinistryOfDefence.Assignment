using AutoMapper;
using MinistryOfDefence.Assignment.DTOs;
using MinistryOfDefence.Assignment.Models;
using System.Collections.Generic;

namespace MinistryOfDefence.Assignment.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingDbContext _dbContext;

        public ShoppingService(ShoppingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddNewItem(ItemDTO itemDTO)
        {
            Item newItem = _mapper.Map<Item>(itemDTO);
            _dbContext.Items.Add(newItem);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            IEnumerable<CategoryDTO> allCategories = null;
            try
            {
                var categories = _dbContext.Categories;
                allCategories = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            }
            catch (Exception ex)
            {
                //TODO:Logging the exception
            }

            return allCategories;
        }

        public IEnumerable<ItemDTO> GetItemsByCategory(int categoryId)
        {
            IEnumerable<ItemDTO> allItemsForCategoryId = null;
            try
            {
                var items = _dbContext.Items.Where(x => x.CategoryId.Equals(categoryId));
                allItemsForCategoryId = _mapper.Map<IEnumerable<ItemDTO>>(items);
            }
            catch (Exception ex)
            {
                //TODO:Logging the exception
            }
            return allItemsForCategoryId;
        }
    }
}
