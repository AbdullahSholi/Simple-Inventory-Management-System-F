namespace Simple_Inventory_Management_System;

public class ConsoleIO : IInputHandler, IOutputHandler
{
    public string? ReadLine() => Console.ReadLine();

    public double ReadDouble() => double.Parse(ReadLine());

    public int ReadInt() => int.Parse(ReadLine());

    public void WriteLine(string message) => Console.WriteLine(message);
}