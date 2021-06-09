namespace Model.In
{
    public class ConsultationModel
    {
        public int ProblematicId { get; set; }
        public PacientModel Pacient { get; set; }
        public int Duration { get; set; }
    }
}
