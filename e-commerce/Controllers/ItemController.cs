using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using list.Services;
using list.Models;

namespace list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemServices _itemServices;

        public ItemController(ItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        [HttpGet]
        public async Task<List<Item>> GetItens()
             => await _itemServices.GetAsync();

        [HttpPut("{id}")]
        public async Task<Item> UpdateItem(string id, Item item)
        {
            Item retorno = await _itemServices.UpdateAsync(id, item);
            return retorno;
        }
        [HttpPost]
        public async Task<Item> PostItem(Item item)
        {
            await _itemServices.CreateAsync(item);

            return item;
        }
    }
}
