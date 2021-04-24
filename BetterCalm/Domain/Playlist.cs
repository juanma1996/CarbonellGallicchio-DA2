using System.Collections.Generic;

namespace Domain
{
    public class Playlist
    {
        public int Id { get; set; }
        public List<CategoryPlaylist> Categories { get; set; }
        public List<AudioContentPlaylist> AudioContents { get; set; }
    }
}