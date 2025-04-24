using MongoDB.Bson;
using MongoDB.Driver;
using Simple_Inventory_Management_System.Entity;
using Simple_Inventory_Management_System.Utilities;

namespace Simple_Inventory_Management_System.StrategyPattern;

public class MongoDatabase : IDatabaseStrategy
{
    private readonly IMongoCollection<Product>? _collection;
    public MongoDatabase(string connectionString)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("SimpleInventoryManagementSystem");
        var collection = database.GetCollection<Product>("products");
        _collection = collection;
    }
    public async Task Add(Product product)
    {
        await _collection.InsertOneAsync(product);
    }

    List<Product> IDatabaseStrategy.GetAllProducts()
    {
        return _collection.Find(new BsonDocument()).Project<Product>(Builders<Product>.Projection.Exclude("_id")).ToList();
    }

    public Task DeleteProduct(string? productName)
    {
        _collection.DeleteMany(p => p.ProductName == productName);
        return Task.CompletedTask;
    }

    public List<Product> FindProductsByName(string? productName)
    {
        var products = _collection.Find(p => p.ProductName == productName).ToList();
        return products;
    }

    public Task EditProduct(Product updatedProduct)
    {
        var update = Builders<Product>.Update
            .Set(p => p.ProductPrice, updatedProduct.ProductPrice)
            .Set(p => p.Quantity, updatedProduct.Quantity);
        var result = _collection.UpdateOne(
            p => p.ProductName == updatedProduct.ProductName,
            update
        );
        if (result.MatchedCount == 0)
        {
            Console.WriteLine(Messages.ProductNotFound);
        }
        return Task.CompletedTask;
    }
    
}