using Simple_Inventory_Management_System.IO;
using Simple_Inventory_Management_System.StrategyPattern;

namespace Simple_Inventory_Management_System;

public class Inventory
{
    public static void Main()
    {
        IDatabaseStrategy sqlDatabaseStrategy = new SqlServerDatabase(Constants.Constants.SqlServerConnectionString);
        IDatabaseStrategy mongoDatabaseStrategy = new MongoDatabase(Constants.Constants.MongoConnectionString);
        IDatabaseStrategy inMemoryDatabaseStrategy = new InMemoryDatabase();
        
        var inputHandler = new ConsoleIo();
        var outputHandler = new ConsoleIo();
        var readableService = new StrategyPattern.Service.Service(sqlDatabaseStrategy, inputHandler, outputHandler);
        var writableService = new StrategyPattern.Service.Service(sqlDatabaseStrategy, inputHandler, outputHandler);
        var menu = new Utilities.Utilities(readableService, writableService, inputHandler, outputHandler);
        menu.ShowMenu();
    }
}