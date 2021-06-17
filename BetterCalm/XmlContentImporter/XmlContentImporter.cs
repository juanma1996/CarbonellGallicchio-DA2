using ImporterInterface;
using ImporterInterface.Common;
using ImporterInterface.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace XmlContentImporter
{
    public class XmlContentImporter : IContentImporter
    {
        public string GetId()
        {
            return "xml";
        }

        public ContentImporterModel ImportContent(string filePath)
        {
            string file = File.ReadAllText(filePath);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(file);
            string json = JsonConvert.SerializeXmlNode(doc.FirstChild, Newtonsoft.Json.Formatting.None, true);

            var serializerOptions = new JsonSerializerOptions
            {
                Converters = { new ImporterInterface.Common.JsonConverter(), new IntToStringConverter() },
                PropertyNameCaseInsensitive = true
            };
            ContentImporterModel exampleJson = System.Text.Json.JsonSerializer.Deserialize<ContentImporterModel>(json, serializerOptions);
            return exampleJson;
        }
    }
}
