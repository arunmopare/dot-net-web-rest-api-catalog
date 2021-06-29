using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Repositories;
namespace Catalog.Controller
{
    // GET /items
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemRepository repository;

        public ItemsController()
        {
            repository = new InMemItemRepository();
        }

        //GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

    }
}