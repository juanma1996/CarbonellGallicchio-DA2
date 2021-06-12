namespace ImporterInterface.Models
{
    public class ContentPlaylistModel
    {
        public PlaylistImporterModel Playlist { get; set; }
        public int PlaylistId { get; set; }
        public ContentImporterModel PlayableContent { get; set; }
        public int PlayableContentId { get; set; }
    }
}
