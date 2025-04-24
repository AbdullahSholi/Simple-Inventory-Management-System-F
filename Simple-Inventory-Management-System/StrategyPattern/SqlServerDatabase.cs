using Microsoft.Data.SqlClient;
using Simple_Inventory_Management_System.Entity;

namespace Simple_Inventory_Management_System.StrategyPattern;

public class SqlServerDatabase : IDatabaseStrategy
{
    private readonly SqlConnection _sqlConnection;

    public SqlServerDatabase(string connectionString)
    {
        _sqlConnection = new SqlConnection(connectionString);
        _sqlConnection.Open();
    }

    public async Task Add(Product product)
    {
        var query =
            "INSERT INTO Products(ProductName, ProductPrice, Quantity) VALUES (@ProductName, @ProductPrice, @Quantity);";
        using (var cmd = new SqlCommand(query, _sqlConnection))
        {
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);

            await cmd.ExecuteNonQueryAsync();
        }
    }

    public List<Product> GetAllProducts()
    {
        var query = "SELECT * FROM Products";
        List<Product> products = new List<Product>();

        using (var cmd = new SqlCommand(query, _sqlConnection))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product
                    (
                        reader["ProductName"].ToString(),
                        Convert.ToDouble(reader["ProductPrice"]),
                        Convert.ToInt32(reader["Quantity"])
                    );
                    products.Add(product);
                }
            }
        } 

        return products;
    }


    public async Task DeleteProduct(string? productName)
    {
        var query = "DELETE FROM Products WHERE ProductName = @ProductName";
        using (var cmd = new SqlCommand(query, _sqlConnection))
        {
            cmd.Parameters.AddWithValue("@ProductName", productName);

            await cmd.ExecuteNonQueryAsync();
        }
    }

    public List<Product> FindProductsByName(string? productName)
    {
        var query = "SELECT * FROM Products WHERE ProductName = @ProductName";
        List<Product> products = new List<Product>();

        using (var cmd = new SqlCommand(query, _sqlConnection))
        {
            cmd.Parameters.AddWithValue("@ProductName", productName ?? string.Empty);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product
                    (
                        reader["ProductName"].ToString(),
                        Convert.ToDouble(reader["ProductPrice"]),
                        Convert.ToInt32(reader["Quantity"])
                    );
                    products.Add(product);
                }
            }
        }

        return products;
    }

    public async Task EditProduct(Product updatedProduct)
    {
        var query =
            "UPDATE Products SET ProductPrice = @ProductPrice, Quantity = @Quantity WHERE ProductName = @ProductName";
        using (var cmd = new SqlCommand(query, _sqlConnection))
        {
            cmd.Parameters.AddWithValue("@ProductPrice", updatedProduct.ProductPrice);
            cmd.Parameters.AddWithValue("@Quantity", updatedProduct.Quantity);
            cmd.Parameters.AddWithValue("@ProductName", updatedProduct.ProductName);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}