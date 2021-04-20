using Model.Out;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.In
{
    public class AudioContentModel
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public List<CategoryBasicInfoModel> Categories { get; set; }
        public List<PlaylistBasicInfoModel> Playlists { get; set; }
    }
}
