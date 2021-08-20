using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;
namespace Catalog.Repositories
{


    public class InMemItemRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Potion",
                Price = 9,
                CreatedDate = DateTimeOffset.UtcNow

            },
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Iron Sword",
                Price = 15,
                CreatedDate = DateTimeOffset.UtcNow

            },
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Shield",
                Price = 40,
                CreatedDate = DateTimeOffset.UtcNow

            },
            new Item
            {
                Id = Guid.NewGuid(),
                Name = "Gold Shield",
                Price = 100,
                CreatedDate = DateTimeOffset.UtcNow

            },
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task createItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task updateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;

        }

        public async Task deleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}