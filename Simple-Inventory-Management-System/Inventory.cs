namespace Simple_Inventory_Management_System
{

    public class Inventory
    {
        public static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
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
                
                
                
                int userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter product name: ");
                        string? productName = Console.ReadLine();
                        
                        Console.WriteLine("Enter product price: ");
                        double price = double.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Enter product quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                    
                        products.Add(new Product(productName, price, quantity));
                        Console.WriteLine($"Product: {productName}, Price: {price}, Quantity: {quantity}. Added successfully!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (userInput == 2)
                {
                    Console.WriteLine("|          Product Name          |          Product Price          |          Product Quantity        |");
                    foreach (Product product in products)
                    {
                        Console.WriteLine($"|          {product.ProductName}          |          {product.ProductPrice}          |          {product.Quantity}        |");
                    }
                    
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