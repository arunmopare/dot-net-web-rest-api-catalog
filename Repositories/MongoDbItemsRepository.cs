
using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDbItemsRepository : IItemRepository
    {
        private const string databaseName = "Catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterDefinitionBuilder = Builders<Item>.Filter;



        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);

            itemsCollection = database.GetCollection<Item>(collectionName);

        }

        public void createItem(Item item)
        {
            itemsCollection.InsertOne(item);
        }

        public Item GetItem(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(item => item.Id, id);

            return itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return itemsCollection.Find(new BsonDocument()).ToList();
        }

        public void updateItem(Item item)
        {
            var filter = filterDefinitionBuilder.Eq(existingItem => existingItem.Id, item.Id);
            itemsCollection.ReplaceOne(filter, item);
        }

        public void deleteItem(Guid id)
        {
            var filter = filterDefinitionBuilder.Eq(existingItem => existingItem.Id, id);
            itemsCollection.DeleteOne(filter);
        }
    }
}