namespace Simple_Inventory_Management_System.StrategyPattern.Service;

public interface IInventoryServiceWritable : IInventoryService
{
    public void AddProduct();
    public void EditProduct();
    public void DeleteProduct();
}