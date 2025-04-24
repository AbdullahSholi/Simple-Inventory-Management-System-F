using Simple_Inventory_Management_System.IO;
using Simple_Inventory_Management_System.Service;

namespace Simple_Inventory_Management_System.Utilities;

public class Utilities
{
    private readonly IInputHandler _input;
    private readonly IOutputHandler _output;
    private readonly IInventoryServiceReadable _readableService;
    private readonly IInventoryServiceWritable _writableService;

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
            { 6, () => false }
        };

        if (menuOptions.TryGetValue(userInput, out var operation)) return operation();

        _output.WriteLine(Messages.InvalidOperation);
        return true;
    }

    public void ShowMenu()
    {
        var continueRunning = true;
        while (continueRunning)
        {
            _output.WriteLine(Messages.InventoryMenu);
            var userInput = _input.ReadInt();
            continueRunning = MenuOptions(userInput);
        }
    }
}