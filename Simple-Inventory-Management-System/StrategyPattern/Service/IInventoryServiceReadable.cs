using Simple_Inventory_Management_System.Entity;

namespace Simple_Inventory_Management_System.StrategyPattern.Service;

public interface IInventoryServiceReadable : IInventoryService
{
    void ViewAllProducts();
    
    List<Product> FindProducts();
    
    void PrintFoundProducts();
}