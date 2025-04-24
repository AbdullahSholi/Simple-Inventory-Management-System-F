namespace Simple_Inventory_Management_System.IO;

public interface IInputHandler : IOHandler
{
    string? ReadLine();
    double ReadDouble();
    int ReadInt();
}