using System.Collections.Generic;

namespace Domain
{
    public class Problematic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PsychologistProblematic> Psychologists { get; set; }
    }
}
