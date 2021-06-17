using System;
using System.Collections.Generic;

namespace Domain
{
    public class Psychologist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConsultationMode { get; set; }
        public string Direction { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PsychologistProblematic> Problematics { get; set; }
        public int Fee { get; set; }
    }
}
