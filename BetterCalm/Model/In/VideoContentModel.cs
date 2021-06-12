using System;
using System.Collections.Generic;

namespace Model.In
{
    public class VideoContentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string VideoUrl { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<PlaylistModel> Playlists { get; set; }
    }
}
