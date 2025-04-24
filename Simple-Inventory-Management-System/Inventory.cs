using Simple_Inventory_Management_System.IO;
using Simple_Inventory_Management_System.Repository;

namespace Simple_Inventory_Management_System;

public class Inventory
{
    public static void Main()
    {
        var inputHandler = new ConsoleIo();
        var outputHandler = new ConsoleIo();
        var repository = new ProductRepository();
        var readableService = new Service.Service(repository, inputHandler, outputHandler);
        var writableService = new Service.Service(repository, inputHandler, outputHandler);
        var menu = new Utilities.Utilities(readableService, writableService, inputHandler, outputHandler);
        menu.ShowMenu();
    }
}