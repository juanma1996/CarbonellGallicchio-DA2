namespace ImporterInterface
{
    public interface IContentImporter
    {
        ContentImporter ImportContent();
        string GetId();
    }
}