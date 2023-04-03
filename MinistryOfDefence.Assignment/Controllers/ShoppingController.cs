using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinistryOfDefence.Assignment.DTOs;
using MinistryOfDefence.Assignment.Services;

namespace MinistryOfDefence.Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        IShoppingService _shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categories = _shoppingService.GetCategories();
            if (categories == null || !categories.Any())
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public IActionResult Get(int categoryId)
        {
            var items = _shoppingService.GetItemsByCategory(categoryId);
            if(items == null || !items.Any())
            {
                return NotFound();
            }

            return Ok(items);
        }

        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetItemsAndCategories()
        {
            var allItems = await _shoppingService.GetItemsAndCategories();
            return Ok(allItems.Categories.Values);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemDTO item)
        {
            if (item == null)
            {
                return BadRequest("Can't save empty item");
            }
            if (string.IsNullOrEmpty(item.Name))
            {
                return BadRequest("Name is required");
            }
            if(item.CategoryId == 0)
            {
                return BadRequest("CategoryId must be greater than zero");
            }

            var result = await _shoppingService.AddNewItem(item);
            return Created("/Shopping", result);
        }
    }
}
