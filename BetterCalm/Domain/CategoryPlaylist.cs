﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CategoryPlaylist
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Playlist Playlist { get; set; }
        public int PlaylistId { get; set; }
    }
}
