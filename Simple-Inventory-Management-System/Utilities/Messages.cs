namespace Simple_Inventory_Management_System.Utilities;

public class Messages
{
    public const string EnterProductName = "Enter product name: ";
    public const string EnterProductPrice = "Enter product price: ";
    public const string EnterProductQuantity = "Enter product quantity: ";
    public const string EnterNewPrice = "Enter new price: ";
    public const string EnterNewQuantity = "Enter new quantity: ";
    public const string ProductUpdated = "Product updated!";
    public const string ProductDeletedSuccessfully = "Product deleted successfully!";
    public const string ProductNotFound = "Product not found!";
    public const string InvalidOperation = "Invalid operation!";
    
    public const string ProductsResultHeader =
        "|          Product Name          |          Product Price          |          Product Quantity        |";

    public const string InventoryMenu = """
                                        ----------------- Simple Inventory Management System ------------------
                                        | 1. Add a product                                                     |
                                        | 2. View all the products                                             |
                                        | 3. Edit a product                                                    |
                                        | 4. Delete a product                                                  |
                                        | 5. Search for a product                                              |
                                        | 6. Exit                                                              |
                                        -----------------------------------------------------------------------
                                        """;
}