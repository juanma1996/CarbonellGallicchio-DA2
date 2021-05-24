using ImporterInterface;
using ImporterInterface.Models;
using System.IO;
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
            XmlSerializer serializer = new XmlSerializer(typeof(ContentImporterModel));
            ContentImporterModel contentImporterModel = null;
            using (Stream reader = new FileStream(filePath, FileMode.Open))
            {
                contentImporterModel = (ContentImporterModel)serializer.Deserialize(reader);
            }

            return contentImporterModel;
        }
    }
}
