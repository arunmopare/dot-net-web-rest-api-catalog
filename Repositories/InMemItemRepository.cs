using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;
namespace Catalog.Repositories
{
    public class InMemItemRepository
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

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

    }
}