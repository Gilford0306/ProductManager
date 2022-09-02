
namespace ProductManager.Model
{
    internal class ModelSeting
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public bool Trusted_Connection { get; set; }

        public ModelSeting(string server, string database, bool trusted_Connection)
        {
            Server = server;
            Database = database;
            Trusted_Connection = trusted_Connection;
        }
        public override string ToString()
        {
            return $"Server={Server};Database = {Database};Trusted_Connection={Trusted_Connection};";
        }
    }
}
