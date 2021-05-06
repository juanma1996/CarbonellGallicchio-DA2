using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.In
{
    public class PsychologistModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ConsultationMode { get; set; }
        public string Direction { get; set; }
        [Required]
        public List<ProblematicModel> Problematics { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
