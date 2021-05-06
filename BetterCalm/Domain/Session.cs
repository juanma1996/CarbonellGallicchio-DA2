using System;

namespace Domain
{
    public class Session
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public Administrator Administrator { get; set; }
    }
}
