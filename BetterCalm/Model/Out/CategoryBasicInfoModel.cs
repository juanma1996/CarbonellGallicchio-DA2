using Domain;
using System.Collections.Generic;

namespace Model.Out
{
    public class CategoryBasicInfoModel
    {
        public int Id { get; private set; }
        public List<PlaylistBasicInfoModel> Playlists { get; private set; }


        public CategoryBasicInfoModel(Category category)
        {
            this.Id = category.Id;
            foreach (var item in category.Playlists)
            {
                var playlist = new PlaylistBasicInfoModel(item);
                this.Playlists.Add(playlist);
            }
        }
    }
}
