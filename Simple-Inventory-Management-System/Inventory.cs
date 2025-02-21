namespace Simple_Inventory_Management_System
{

    public class Inventory
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----------------- Simple Inventory Management System ------------------");
                Console.WriteLine("| 1. Add a product                                                     |");
                Console.WriteLine("| 2. View all the products                                             |");
                Console.WriteLine("| 3. Edit a product                                                    |");
                Console.WriteLine("| 4. Delete a product                                                  |");
                Console.WriteLine("| 5. Search for a product                                              |");
                Console.WriteLine("| 6. Exit                                                              |");
                Console.WriteLine("-----------------------------------------------------------------------");
                
                List<Product> products = new List<Product>();
                
                int userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 1)
                {
                    
                }
                else if (userInput == 2)
                {
                    
                } else if (userInput == 3)
                {
                    
                } else if (userInput == 4)
                {
                    
                } else if (userInput == 5)
                {
                    
                } else if (userInput == 6)
                {
                    break;
                }
                else
                {
                    
                }
            }
            
        }
    }
}