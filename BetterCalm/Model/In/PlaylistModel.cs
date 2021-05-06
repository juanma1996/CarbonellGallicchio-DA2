using System.ComponentModel.DataAnnotations;

namespace Model.In
{
    public class PlaylistModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, StringLength(150)]
        public string Description { get; set; }
    }
}
