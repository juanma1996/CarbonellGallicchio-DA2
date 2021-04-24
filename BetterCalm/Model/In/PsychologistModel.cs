using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.Out;

namespace Model.In
{
    public class PsychologistModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ConsultationMode { get; set; }
        [Required]
        public string Direction { get; set; }
        [Required]
        public List<ProblematicModel> Problematics { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
