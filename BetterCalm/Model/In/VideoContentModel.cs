using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.In
{
    public class VideoContentModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string VideoUrl { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public List<PlaylistModel> Playlists { get; set; }
    }
}
