using Simple_Inventory_Management_System.Entity;

namespace Simple_Inventory_Management_System.StrategyPattern;

public interface IDatabaseStrategy
{
    public Task Add(Product product);

    public Task EditProduct(Product updatedProduct);

    public List<Product> GetAllProducts();
    public Task DeleteProduct(string? productName);
    
    public List<Product> FindProductsByName(string? productName);
    
}