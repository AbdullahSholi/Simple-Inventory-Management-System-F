namespace Simple_Inventory_Management_System.Entity;

public class Product
{
    public Product(string? productName, double productPrice, int quantity)
    {
        ProductName = productName;
        ProductPrice = productPrice;
        Quantity = quantity;
    }

    public string? ProductName { get; set; }
    public double ProductPrice { get; set; }
    public int Quantity { get; set; }
}