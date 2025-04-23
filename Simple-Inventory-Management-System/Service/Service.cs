using Simple_Inventory_Management_System.Entity;
using Simple_Inventory_Management_System.IO;
using Simple_Inventory_Management_System.Repository;
using Simple_Inventory_Management_System.Utilities;

namespace Simple_Inventory_Management_System.Service;

public class Service : IInventoryServiceReadable, IInventoryServiceWritable
{
    private readonly IInputHandler _input;
    private readonly IOutputHandler _output;
    private readonly IProductRepository _repository;

    public Service(IProductRepository repository, IInputHandler input, IOutputHandler output)
    {
        _repository = repository;
        _input = input;
        _output = output;
    }

    public void ViewAllProducts()
    {
        _output.WriteLine(Messages.ProductsResultHeader);
        _repository.GetAllProducts().ForEach(product =>
            _output.WriteLine(
                $"|          {product.ProductName}          |          {product.ProductPrice}          |          {product.Quantity}        |"));
    }

    public void AddProduct()
    {
        try
        {
            _output.WriteLine(Messages.EnterProductName);
            var productName = _input.ReadLine();

            _output.WriteLine(Messages.EnterProductPrice);
            var price = _input.ReadDouble();

            _output.WriteLine(Messages.EnterProductQuantity);
            var quantity = _input.ReadInt();

            _repository.Add(new Product(productName, price, quantity));
            _output.WriteLine($"Product: {productName}, Price: {price}, Quantity: {quantity}. Added successfully!");
        }
        catch (Exception e)
        {
            _output.WriteLine(e.Message);
        }
    }

    public void EditProduct()
    {
        var productsToUpdate = FindProducts();
        if (productsToUpdate.Any())
            foreach (var product in productsToUpdate)
            {
                _output.WriteLine(Messages.EnterNewPrice);
                var price = _input.ReadDouble();
                _output.WriteLine(Messages.EnterNewQuantity);
                var quantity = _input.ReadInt();

                var updatedProduct = new Product(product.ProductName, price, quantity);
                _repository.EditProduct(updatedProduct);
                _output.WriteLine(Messages.ProductUpdated);
            }
        else
            _output.WriteLine(Messages.ProductNotFound);
    }

    private List<Product> FindProducts()
    {
        _output.WriteLine(Messages.EnterProductName);
        var productName = _input.ReadLine();
        var productsToUpdate =
            _repository.GetAllProducts().Where(product => product.ProductName == productName).ToList();

        return productsToUpdate;
    }
}