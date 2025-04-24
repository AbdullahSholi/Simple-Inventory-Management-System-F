using Simple_Inventory_Management_System.Entity;

namespace Simple_Inventory_Management_System.StrategyPattern;

public class InMemoryDatabase : IDatabaseStrategy
{
    private readonly List<Product> _products = new();

    public Task Add(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Task DeleteProduct(string? productName)
    {
        _products.RemoveAll(p => p.ProductName == productName);
        return Task.CompletedTask;
    }

    public List<Product> FindProductsByName(string? productName)
    {
        var products = _products.FindAll(p => p.ProductName == productName);
        return products;
    }

    public Task EditProduct(Product updatedProduct)
    {
        var existing = _products.FirstOrDefault(p => p.ProductName == updatedProduct.ProductName);
        if (existing != null)
        {
            existing.ProductPrice = updatedProduct.ProductPrice;
            existing.Quantity = updatedProduct.Quantity;
        }

        return Task.CompletedTask;
    }
}