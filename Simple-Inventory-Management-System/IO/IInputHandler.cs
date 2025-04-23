namespace Simple_Inventory_Management_System.IO;

public interface IInputHandler
{
    string? ReadLine();
    double ReadDouble();
    int ReadInt();
}