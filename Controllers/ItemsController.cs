using System.Net.NetworkInformation;
using System.Data.Common;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Dtos;
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
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        //GET /items/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)

        {
            var item = repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        //GET /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.createItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());

        }

        //PUT /items

        [HttpPut("{id}")]
        public ActionResult updateItem(Guid id, UpdateItemDto itemDto)
        {
            var exutingItem = repository.GetItem(id);

            return;

        }
    }
}