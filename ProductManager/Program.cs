using Dapper;
using System.Data.SqlClient;
using ProductManager.Model;
using ProductManager.Controller;
using System.Text.Json;

do
{

    ConnectionControler controller1 = new ConnectionControler(@"D:\Projects\ProductManager\ProductManager\Connection_String\setting.json");
    controller1.Download();
    SqlConnection connect = SingletonConnection.GetInstance(controller1.defaultsetting).GetConnection();
    ModelSeting defaultconnect = JsonSerializer.Deserialize<ModelSeting>(File.ReadAllText(@"D:\Projects\ProductManager\ProductManager\Connection_String\setting.json"));
    string mybase = defaultconnect.Database.ToString();
    Console.WriteLine("\tProducts");
    Console.WriteLine("All Products - press 1");
    Console.WriteLine("Add Product - press 2");
    Console.WriteLine("Edit Product - press 3");
    Console.WriteLine("Deleted Product - press 4");
    int k = int.Parse(Console.ReadLine());
    switch (k)
    {
        case 1:
            connect.Open();
            LogerCreate.Log($"Open datbase - {mybase}", LogLevel.Information);
            var produts = connect.Query<Product>("SELECT * FROM [Product];");
            produts.ToList().ForEach(Console.WriteLine);
            if (produts.Count() == 0)
                Console.WriteLine("No Products yet");
            LogerCreate.Log($"Get items {produts.Count()} from database - {mybase} ", LogLevel.Information);
            connect.Close();
            LogerCreate.Log($"Close datbase {mybase}", LogLevel.Information);

            break;
        case 2:
            Console.WriteLine("Input name - ");
            string name = Console.ReadLine();
            Console.WriteLine("Input CategoryId - ");
            int cat = int.Parse(Console.ReadLine());
            Console.WriteLine("Input SupplierId - ");
            int sup = int.Parse(Console.ReadLine());
            connect.Open();
            LogerCreate.Log($"Open datbase {mybase}", LogLevel.Information);
            Product product = new Product(-1, name, cat, sup);
            int rows = connect.Execute($"INSERT INTO [dbo].[Product]([Name],[CategoryId],[SupplierId])VALUES (\'{product.Name}\', {product.CategoryId},\'{product.SupplierId}\');");
            if (rows > 0)
            {
                Console.WriteLine($"Product added!");
                LogerCreate.Log($"INSERT {name} to datbase {mybase}", LogLevel.Information);
            }
            connect.Close();
            LogerCreate.Log($"Close datbase", LogLevel.Information);
            break;
        case 3:
            connect.Open();
            LogerCreate.Log($"Open datbase", LogLevel.Information);
            var items = connect.Query<Product>("SELECT * FROM [Product];");
            items.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Input Id - ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Input name - ");
            name = Console.ReadLine();
            Console.WriteLine("Input CategoryId- ");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Input SupplierId - ");
            int supplierId = int.Parse(Console.ReadLine());
            rows = connect.Execute($"UPDATE Product SET [Name]='{name}',[CategoryId]='{categoryId}',[SupplierId]='{supplierId}'WHERE id ={id}");
            if (rows > 0)
            {
                Console.WriteLine("Edited");
                LogerCreate.Log($"UPDATE Product id = {id} in database - {mybase}", LogLevel.Information);
            }
            else
            {
                Console.WriteLine("Incorrect ID");
                LogerCreate.Log($"input incorrect ID", LogLevel.Error);
            }
            connect.Close();
            LogerCreate.Log($"Close datbase - {mybase}", LogLevel.Information);
            break;
        case 4:
            connect.Open();
            LogerCreate.Log($"Open datbase - {mybase}", LogLevel.Information);
            items = connect.Query<Product>("SELECT * FROM [Product];");
            items.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Input Id - ");
            id = int.Parse(Console.ReadLine());
            rows = connect.Execute($"DELETE FROM [dbo].[Product] WHERE Id = {id}");
            if (rows > 0)
            {
                Console.WriteLine("Row is deleted");
                LogerCreate.Log($"item id {id} deleted in database - {mybase}", LogLevel.Information);
            }
            else
            {
                Console.WriteLine("Incorrect ID");
                LogerCreate.Log($"input incorrect ID", LogLevel.Error);
            }
            connect.Close();
            LogerCreate.Log($"Close datbase - {mybase}", LogLevel.Information);
            break;
        //        //    case 5:
        //        //        Analysis.Show();
        //        //        break;
        default:
            Console.WriteLine("Only Number 1 - 4");
            break;
    }
} while (true);