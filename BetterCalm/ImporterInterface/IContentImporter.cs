using ImporterInterface.Models;

namespace ImporterInterface
{
    public interface IContentImporter
    {
        ContentImporterModel ImportContent(string filePath);
        string GetId();
    }
}