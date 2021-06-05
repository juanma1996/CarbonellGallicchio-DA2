namespace Domain
{
    public class PlayableContentPlaylist
    {
        public Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
        public PlayableContent PlayableContent { get; set; }
        public int PlayableContentId { get; set; }
    }
}
