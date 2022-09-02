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
    Console.WriteLine("All Supplires - press 1");
    Console.WriteLine("Add Supplires  - press 2");
    Console.WriteLine("Edit Supplires  - press 3");
    Console.WriteLine("Deleted Supplires  - press 4");
    int k = int.Parse(Console.ReadLine());
    switch (k)
    {
        case 1:
            connect.Open();
            LogerCreate.Log($"Open datbase - {mybase}", LogLevel.Information);
            var supl = connect.Query<Supplier>("SELECT * FROM [Supplier];");
            supl.ToList().ForEach(Console.WriteLine);
            if (supl.Count() == 0)
                Console.WriteLine("No Supplires yet");
            LogerCreate.Log($"Get Supplir {supl.Count()} from database - {mybase} ", LogLevel.Information);
            connect.Close();
            LogerCreate.Log($"Close datbase {mybase}", LogLevel.Information);

            break;
        case 2:
            Console.WriteLine("Input name - ");
            string name = Console.ReadLine();
            connect.Open();
            LogerCreate.Log($"Open datbase {mybase}", LogLevel.Information);
            Supplier supplier = new Supplier (-1, name);
            int rows = connect.Execute($"INSERT INTO [dbo].[Supplier]([NameSupplier])VALUES (\'{supplier.NameSupplier}\');");
            if (rows > 0)
            {
                Console.WriteLine($" Supplier added!");
                LogerCreate.Log($"INSERT {name} to datbase {mybase}", LogLevel.Information);
            }
            connect.Close();
            LogerCreate.Log($"Close datbase", LogLevel.Information);
            break;
        case 3:
            connect.Open();
            LogerCreate.Log($"Open datbase", LogLevel.Information);
            var items = connect.Query<Supplier>("SELECT * FROM [Supplier];");
            items.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Input Id - ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Input name - ");
            name = Console.ReadLine();
            rows = connect.Execute($"UPDATE Supplier SET [NameSupplier]='{name}'WHERE id ={id}");
            if (rows > 0)
            {
                Console.WriteLine("Edited");
                LogerCreate.Log($"UPDATE Supplier id = {id} in database - {mybase}", LogLevel.Information);
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
            items = connect.Query<Supplier>("SELECT * FROM [Supplier];");
            items.ToList().ForEach(Console.WriteLine);
            Console.WriteLine("Input Id - ");
            id = int.Parse(Console.ReadLine());
            rows = connect.Execute($"DELETE FROM [dbo].[Supplier] WHERE Id = {id}");
            if (rows > 0)
            {
                Console.WriteLine("Row is deleted");
                LogerCreate.Log($"Supplier id {id} deleted in database - {mybase}", LogLevel.Information);
            }
            else
            {
                Console.WriteLine("Incorrect ID");
                LogerCreate.Log($"input incorrect ID", LogLevel.Error);
            }
            connect.Close();
            LogerCreate.Log($"Close datbase - {mybase}", LogLevel.Information);
            break;
        default:
            Console.WriteLine("Only Number 1 - 4");
            break;
    }
} while (true);