using ImporterInterface.Enums;
using System;
using System.Collections.Generic;

namespace ImporterInterface.Models
{
    public class ContentImporterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public List<CategoryImporterModel> Categories { get; set; }
        public List<PlaylistImporterModel> Playlists { get; set; }
        public PlayableContentType PlayableContentType { get; set; }
    }
}
