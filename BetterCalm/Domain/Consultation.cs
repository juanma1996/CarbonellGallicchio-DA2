namespace Domain
{
    public class Consultation
    {
        public int Id { get; set; }
        public int ProblematicId { get; set; }
        public Pacient Pacient { get; set; }
        public Psychologist Psychologist { get; set; }
        public decimal Cost { get; set; }
        public int Duration { get; set; }
    }
}
