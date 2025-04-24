namespace Simple_Inventory_Management_System.IO;

public class ConsoleIo : IInputHandler, IOutputHandler
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public double ReadDouble()
    {
        return double.Parse(ReadLine());
    }

    public int ReadInt()
    {
        return int.Parse(ReadLine());
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}