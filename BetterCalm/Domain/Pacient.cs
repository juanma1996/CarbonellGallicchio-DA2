using System;

namespace Domain
{
    public class Pacient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
    }
}
