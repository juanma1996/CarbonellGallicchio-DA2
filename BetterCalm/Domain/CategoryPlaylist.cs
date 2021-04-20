using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CategoryPlaylist
    {
        public List<Category> Categories { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
