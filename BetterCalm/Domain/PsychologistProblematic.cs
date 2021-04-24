using System;
namespace Domain
{
    public class PsychologistProblematic
    {
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
        public Problematic Problematic { get; set; }
        public int ProblematicId { get; set; }  
    }
}
