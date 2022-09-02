using ProductManager.Model;
using System.Data.SqlClient;

namespace ProductManager.Controller
{
    internal class SingletonConnection
    {

        private static SingletonConnection _instance = null;
        public static SqlConnection sqlstr { get; private set; }

        private SingletonConnection(string ConnectionStr)
        {
            sqlstr = new SqlConnection(ConnectionStr);

        }
        public SqlConnection GetConnection() => sqlstr;


        public static SingletonConnection GetInstance(ModelSeting settings)
        {

            if (_instance == null)
            {

                _instance = new SingletonConnection(settings.ToString());
            }
            return _instance;
        }

    }
}