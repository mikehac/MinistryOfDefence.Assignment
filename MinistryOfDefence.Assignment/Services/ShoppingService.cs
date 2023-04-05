using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinistryOfDefence.Assignment.DTOs;
using MinistryOfDefence.Assignment.Models;
using System.Collections.Generic;

namespace MinistryOfDefence.Assignment.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IMapper _mapper;
        private readonly ShoppingDbContext _dbContext;
        private readonly ILogger _logger;

        public ShoppingService(ShoppingDbContext dbContext, IMapper mapper, ILogger<ShoppingService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ItemDTO> AddNewItem(ItemDTO itemDTO)
        {
            try
            {
                Item newItem;
                var item = await _dbContext.Items.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(itemDTO.Name.ToLower()) && x.CategoryId.Equals(itemDTO.CategoryId));
                if(item == null)
                {
                    newItem = _mapper.Map<Item>(itemDTO);
                    _dbContext.Items.Add(newItem);
                }
                else
                {
                    item.Amount++;
                    newItem = item;
                }
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<ItemDTO>(newItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddNewItem method failed");
                return null;
            }

        }

        public async Task<ResponseDTO> GetItemsAndCategories()
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                var categories = _mapper.Map<List<CategoryDTO>>(await _dbContext.Categories.ToListAsync());
                var items = _mapper.Map<List<ItemDTO>>(await _dbContext.Items.ToListAsync());
                foreach (var i in items)
                {
                    var currentCategory = categories.SingleOrDefault(x => x.Id == i.CategoryId);
                    if (currentCategory != null)
                    {
                        if (!response.Categories.ContainsKey(currentCategory.Id))
                        {
                            currentCategory.Items.Add(i);
                            response.Categories.Add(currentCategory.Id, currentCategory);
                        }
                        else
                        {
                            response.Categories[currentCategory.Id].Items.Add(i);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetItemsAndCategories method failed");
            }

            return response;
        }
        public IEnumerable<CategoryDTO> GetCategories()
        {
            _logger.LogInformation("GetCategories START");
            IEnumerable<CategoryDTO> allCategories = null;
            try
            {
                var categories = _dbContext.Categories;
                allCategories = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetCategories method failed");
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
                _logger.LogError(ex, "GetItemsByCategory method failed");
            }
            return allItemsForCategoryId;
        }
    }
}
