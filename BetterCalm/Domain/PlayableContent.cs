using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class PlayableContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public List<PlayableContentCategory> Categories { get; set; }
        public List<PlayableContentPlaylist> Playlists { get; set; }
    }
}
