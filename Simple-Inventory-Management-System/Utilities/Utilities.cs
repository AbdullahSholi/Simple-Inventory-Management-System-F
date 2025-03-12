namespace Simple_Inventory_Management_System;

public class Utilities
{
    private readonly IInventoryServiceReadable _readableService;
    private readonly IInventoryServiceWritable _writableService;
    private readonly IInputHandler _input;
    private readonly IOutputHandler _output;

    public Utilities(IInventoryServiceReadable readableService, IInventoryServiceWritable writableService,
        IInputHandler inputHandler, IOutputHandler outputHandler)
    {
        _readableService = readableService;
        _writableService = writableService;
        _input = inputHandler;
        _output = outputHandler;
    }

    private bool MenuOptions(int userInput)
    {
        var menuOptions = new Dictionary<int, Func<bool>>
        {
            {
                1, () =>
                {
                    _writableService.AddProduct();
                    return true;
                }
            },
            {
                2, () =>
                {
                    _readableService.ViewAllProducts();
                    return true;
                }
            },
            {
                3, () =>
                {
                    _writableService.EditProduct();
                    return true;
                }
            },
            { 4, () => { return true; } },
            { 5, () => { return true; } },
            { 6, () => false },
        };

        if (menuOptions.TryGetValue(userInput, out var operation))
        {
            return operation();
        }

        _output.WriteLine("Invalid Operation");
        return true;
    }

    public void ShowMenu()
    {
        bool continueRunning = true;
        while (continueRunning)
        {
            ShowDashboard();
            int userInput = _input.ReadInt();
            continueRunning = MenuOptions(userInput);
        }
    }

    public void ShowDashboard()
    {
        _output.WriteLine("----------------- Simple Inventory Management System ------------------");
        _output.WriteLine("| 1. Add a product                                                     |");
        _output.WriteLine("| 2. View all the products                                             |");
        _output.WriteLine("| 3. Edit a product                                                    |");
        _output.WriteLine("| 4. Delete a product                                                  |");
        _output.WriteLine("| 5. Search for a product                                              |");
        _output.WriteLine("| 6. Exit                                                              |");
        _output.WriteLine("-----------------------------------------------------------------------");
    }
}