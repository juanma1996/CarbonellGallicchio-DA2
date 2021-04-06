using Domain;

namespace Model.Out
{
    public class PlaylistBasicInfoModel
    {
        public int Id { get; private set; }

        public PlaylistBasicInfoModel(Playlist playlist)
        {
            this.Id = playlist.Id;
        }
    }
}
