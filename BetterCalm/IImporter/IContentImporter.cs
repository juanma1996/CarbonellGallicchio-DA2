namespace ImporterInterface
{
    public interface IContentImporter
    {
        ExternalContent ImportContent();
        string GetId();
    }
}