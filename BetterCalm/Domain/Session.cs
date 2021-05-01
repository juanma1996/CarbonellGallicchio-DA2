using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Session
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
    }
}
