using System;
using System.Collections.Generic;

namespace Model.Out
{
    public class AudioContentBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public List<PlaylistBasicInfoModel> Playlists { get; set; }
        public List<CategoryBasicInfoModel> Categories { get; set; }
    }
}
