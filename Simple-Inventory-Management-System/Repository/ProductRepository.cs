using Simple_Inventory_Management_System.Entity;

namespace Simple_Inventory_Management_System.Repository;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> products = new();

    public void Add(Product product)
    {
        products.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return products;
    }

    public void EditProduct(Product updatedProduct)
    {
        var existing = products.FirstOrDefault(p => p.ProductName == updatedProduct.ProductName);
        if (existing != null)
        {
            existing.ProductPrice = updatedProduct.ProductPrice;
            existing.Quantity = updatedProduct.Quantity;
        }
    }
}