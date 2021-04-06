using System.Collections.Generic;

namespace BetterCalm.WebApi.Controllers
{
    public class Category
    {
        public int Id { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}