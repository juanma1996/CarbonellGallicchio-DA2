using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AudioContentPlaylist
    {
        public Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
        public AudioContent AudioContent { get; set; }
        public int AudioContentId { get; set; }
    }
}
