namespace Simple_Inventory_Management_System.IO;

public interface IOutputHandler : IOHandler
{
    void WriteLine(string message);
}