using Domain;
using System.Collections.Generic;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id { get; set; }
        public List<PlaylistBasicInfoModel> Playlists { get; set; }
    }
}