using System.Net.NetworkInformation;
using System.Data.Common;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Dtos;
using System.Threading.Tasks;

namespace Catalog.Controller
{
    // GET /items
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository repository;

        public ItemsController(IItemRepository repository)
        {
            this.repository = repository;
        }

        //GET /items
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync())
                        .Select(item => item.AsDto());
            return items;
        }

        //GET /items/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)

        {
            var item = await repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        //GET /items
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.createItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());

        }

        //PUT /items

        [HttpPut("{id}")]
        public async Task<ActionResult> updateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var exitingItem = await repository.GetItemAsync(id);
            if (exitingItem == null)
            {
                return NotFound();
            }

            Item updateditem = exitingItem with
            {

                Name = itemDto.Name,
                Price = itemDto.Price
            };
            await repository.updateItemAsync(updateditem);
            return NoContent();

        }

        // DELETE /items/
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }
            await repository.deleteItemAsync(id);
            return NoContent();
        }
    }
}