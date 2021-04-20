using System.Collections.Generic;

namespace Domain
{
    public class Playlist
    {
        public int Id { get; set; }
        public List<Category> Categories { get; set; }
    }
}