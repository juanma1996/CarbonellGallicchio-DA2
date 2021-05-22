using ImporterInterface;
using System.IO;
using System.Text.Json;

namespace JsonContentImporter
{
    public class JsonContentImporter : IContentImporter
    {
        public string GetId()
        {
            return "json";
        }

        public ContentImporterModel ImportContent(string filePath)
        {
            string file = File.ReadAllText(filePath);
            ContentImporterModel exampleJson = JsonSerializer.Deserialize<ContentImporterModel>(file);
            return exampleJson;
        }
    }
}
