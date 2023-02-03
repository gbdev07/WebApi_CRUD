using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Test.Models;
using WebApi_Test.Repository.Interfaces;

namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ItemModel>>> GetAllItems()
        {
            List<ItemModel> items = await _itemRepository.ListAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> SearchItemById(int id)
        {
            ItemModel item = await _itemRepository.GetItemById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> NewItem([FromBody] ItemModel itemModel)
        {
            ItemModel newItem = await _itemRepository.AddItem(itemModel);
            return Ok(newItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemModel>> UpdateItemInfos([FromBody] ItemModel itemModel, int id)
        {
            itemModel.Id = id;
            ItemModel item = await _itemRepository.UpdateItem(itemModel, id);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemModel>> DeleteItem(int id)
        {
            bool deleted = await _itemRepository.DeleteItem(id);
            return Ok(deleted);
        }
    }
}
