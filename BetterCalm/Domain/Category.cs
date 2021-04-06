using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}