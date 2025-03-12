namespace Simple_Inventory_Management_System;

public class Inventory
{
    
    public static void Main()
    {
        IInputHandler inputHandler = new ConsoleIO();
        IOutputHandler outputHandler = new ConsoleIO();
        IProductRepository repository = new ProductRepository();
        IInventoryServiceReadable readableService = new Service(repository, inputHandler, outputHandler );
        IInventoryServiceWritable writableService = new Service(repository, inputHandler, outputHandler);
        Utilities menu = new Utilities(readableService, writableService, inputHandler, outputHandler);
        menu.ShowMenu();
    }
}