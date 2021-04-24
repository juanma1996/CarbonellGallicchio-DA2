namespace Domain
{
    public class AudioContentCategory
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public AudioContent AudioContent { get; set; }
        public int AudioContentId { get; set; }
    }
}