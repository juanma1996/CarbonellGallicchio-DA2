using System.Collections.Generic;

namespace Domain
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryPlaylist> Categories { get; set; }
        public List<PlayableContentPlaylist> PlayableContents { get; set; }
    }
}