using ImporterInterface;
using ImporterInterface.Common;
using ImporterInterface.Models;
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
            var serializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonConverter() },
                PropertyNameCaseInsensitive = true
            };
            ContentImporterModel exampleJson = JsonSerializer.Deserialize<ContentImporterModel>(file, serializerOptions);
            return exampleJson;
        }
    }
}
