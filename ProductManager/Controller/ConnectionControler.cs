using System.Text.Json;
using ProductManager.Model;
using System.Data.SqlClient;

namespace ProductManager.Controller
{
    internal class ConnectionControler
    {

        readonly string fileName;
        public ModelSeting defaultsetting { get; set; }
        public ConnectionControler(string fileName = "setting.json")
        {
            this.fileName = fileName;

        }
        public void Download() => defaultsetting = JsonSerializer.Deserialize<ModelSeting>(File.ReadAllText(fileName));
        public void SetSettings(ModelSeting setting)
        {
            defaultsetting = setting;

        }
        public void Save() => File.WriteAllText(fileName, JsonSerializer.Serialize<ModelSeting>(defaultsetting));
    }
}



