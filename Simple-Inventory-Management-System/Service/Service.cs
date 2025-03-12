namespace Simple_Inventory_Management_System;

public class Service : IInventoryServiceReadable, IInventoryServiceWritable
{
    private readonly IProductRepository _repository;
    private readonly IInputHandler _input;
    private readonly IOutputHandler _output;

    public Service(IProductRepository repository, IInputHandler input, IOutputHandler output)
    {
        _repository = repository;
        _input = input;
        _output = output;
    }

    public void AddProduct()
    {
        try
        {
            _output.WriteLine("Enter product name: ");
            string? productName = _input.ReadLine();

            _output.WriteLine("Enter product price: ");
            double price = _input.ReadDouble();

            _output.WriteLine("Enter product quantity: ");
            int quantity = _input.ReadInt();

            _repository.Add(new Product(productName, price, quantity));
            _output.WriteLine($"Product: {productName}, Price: {price}, Quantity: {quantity}. Added successfully!");
        }
        catch (Exception e)
        {
            _output.WriteLine(e.Message);
        }
    }

    public void ViewAllProducts()
    {
        _output.WriteLine(
            "|          Product Name          |          Product Price          |          Product Quantity        |");
        _repository.GetAllProducts().ForEach(product =>
            _output.WriteLine(
                $"|          {product.ProductName}          |          {product.ProductPrice}          |          {product.Quantity}        |"));
    }

    public void EditProduct()
    {
        var productsToUpdate = FindProducts();
        if (productsToUpdate.Any())
        {
            foreach (Product product in productsToUpdate)
            {
                _output.WriteLine("Enter new price: ");
                double price = _input.ReadDouble();
                _output.WriteLine("Enter new quantity: ");
                int quantity = _input.ReadInt();

                var updatedProduct = new Product(product.ProductName, price, quantity);
                _repository.EditProduct(updatedProduct);
                _output.WriteLine("Product updated!");
            }
        }
        else
        {
            _output.WriteLine("Product not found!");
        }
    }

    private List<Product> FindProducts()
    {
        _output.WriteLine("Enter product name: ");
        string? productName = _input.ReadLine();
        var productsToUpdate =
            _repository.GetAllProducts().Where(product => product.ProductName == productName).ToList();

        return productsToUpdate;
    }
}