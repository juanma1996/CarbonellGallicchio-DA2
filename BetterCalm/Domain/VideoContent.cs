using System;

namespace Domain
{
    public class VideoContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string VideoUrl { get; set; }
    }
}
