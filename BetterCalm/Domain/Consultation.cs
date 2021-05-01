using System;
namespace Domain
{
    public class Consultation
    {
        public int ProblematicId { get; set; }
        public Pacient Pacient { get; set; }
        public Psychologist Psychologist { get; set; }
    }
}
