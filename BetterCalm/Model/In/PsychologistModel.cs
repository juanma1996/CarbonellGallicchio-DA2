using System;
using System.Collections.Generic;

namespace Model.In
{
    public class PsychologistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConsultationMode { get; set; }
        public string Direction { get; set; }
        public List<ProblematicModel> Problematics { get; set; }
        public DateTime CreationDate { get; set; }
        public int Fee { get; set; }
    }
}
