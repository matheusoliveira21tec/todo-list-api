using Microsoft.Extensions.Options;
using MongoDB.Driver;
using list.Models;

namespace list.Services
{
    public class ItemServices
    {
        private readonly IMongoCollection<Item> _itemCollection;

        public ItemServices(IOptions<ItemDatabaseSettings> itemServices)
        {
            var mongoClient = new MongoClient(itemServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(itemServices.Value.DatabaseName);

            _itemCollection = mongoDatabase.GetCollection<Item>
                (itemServices.Value.ItemCollectionName);

        }

        public async Task<List<Item>> GetAsync() =>
            await _itemCollection.Find(x => true).ToListAsync();
       
        public async Task CreateAsync(Item item) =>
            await _itemCollection.InsertOneAsync(item);
        public async Task<Item> UpdateAsync(string itemId, Item itemUpdate)
        {
            var item = await _itemCollection.FindOneAndUpdateAsync(
              Builders<Item>.Filter.Where(it => it.Id == itemId),
              Builders<Item>.Update
                .Set(it => it.Done, itemUpdate.Done));

            return item;
        }
       
    }
}
