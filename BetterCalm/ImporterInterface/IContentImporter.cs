namespace ImporterInterface
{
    public interface IContentImporter
    {
        ContentImporterModel ImportContent(string filePath);
        string GetId();
    }
}