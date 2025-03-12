namespace Simple_Inventory_Management_System;

public interface IProductRepository
{
    public void Add(Product product);

    public void EditProduct(Product updatedProduct);

    public List<Product> GetAllProducts();
    
}