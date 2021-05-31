using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryPlaylist> Playlists { get; set; }
        public List<PlayableContentCategory> AudioContents { get; set; }
    }
}