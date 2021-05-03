using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
