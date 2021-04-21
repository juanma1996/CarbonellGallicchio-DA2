﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AudioContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string CreatorName { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
    }
}
