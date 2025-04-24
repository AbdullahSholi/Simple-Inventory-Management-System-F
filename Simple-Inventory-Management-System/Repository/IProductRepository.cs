using Simple_Inventory_Management_System.Entity;

namespace Simple_Inventory_Management_System.Repository;

public interface IProductRepository
{
    public void Add(Product product);

    public void EditProduct(Product updatedProduct);

    public List<Product> GetAllProducts();
}