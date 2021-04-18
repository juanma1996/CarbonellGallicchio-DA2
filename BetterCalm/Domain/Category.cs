using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Playlist> Playlists { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Category category)
            {
                result = this.Id == category.Id && this.Name.Equals(category.Name) && this.Playlists.Equals(category.Playlists);
            }

            return result;
        }
    }
}