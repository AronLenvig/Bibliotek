using System.Text.Json;

namespace Biblioteket
{
    public class JsonHandler
    {
        // same directory as the program
        private string path = "data.json";
        public string Serialize<T>(T obj)
        {
            // save with indention for readability
            return JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions { WriteIndented = true });
        }

        public T? Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        public void Save<T>(T obj)
        {
            string json = Serialize<T>(obj);
            System.IO.File.WriteAllText(path, json);
        }

        public T Load<T>()
        {
            string json = System.IO.File.ReadAllText(path);
            return Deserialize<T>(json);
        }

        public void SaveBogs(List<Bog> bogs)
        {
            Save<List<Bog>>(bogs);
        }
    }
}