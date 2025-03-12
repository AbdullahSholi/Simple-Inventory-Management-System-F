namespace Simple_Inventory_Management_System;

public interface IInventoryServiceWritable : IInventoryService
{
    public void AddProduct();
    public void EditProduct();
}