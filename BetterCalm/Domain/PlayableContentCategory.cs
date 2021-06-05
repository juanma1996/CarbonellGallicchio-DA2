namespace Domain
{
    public class PlayableContentCategory
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public PlayableContent PlayableContent { get; set; }
        public int PlayableContentId { get; set; }
    }
}