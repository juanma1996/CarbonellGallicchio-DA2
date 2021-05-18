namespace ImporterInterface
{
    public interface IContentImporter
    {
        ContentImporterModel ImportContent();
        string GetId();
    }
}