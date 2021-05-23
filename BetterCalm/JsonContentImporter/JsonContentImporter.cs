using ImporterInterface;
using System.Diagnostics;
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
            ContentImporterModel exampleJson = JsonSerializer.Deserialize<ContentImporterModel>(file, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return exampleJson;
        }
    }
}
