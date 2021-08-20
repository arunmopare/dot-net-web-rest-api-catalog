using System.Collections.Generic;
using System;
using Catalog.Entities;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();

        Task createItemAsync(Item item);

        Task updateItemAsync(Item item);

        Task deleteItemAsync(Guid id);

    }
}