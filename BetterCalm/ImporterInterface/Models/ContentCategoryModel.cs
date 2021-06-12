
namespace ImporterInterface.Models
{
    public class ContentCategoryModel
    {
        public CategoryImporterModel Category { get; set; }
        public int CategoryId { get; set; }
        public ContentImporterModel PlayableContent { get; set; }
        public int PlayableContentId { get; set; }
    }
}
