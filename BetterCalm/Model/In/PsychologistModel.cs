using System;
using System.ComponentModel.DataAnnotations;

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
        public DateTime CreationDate { get; set; }
    }
}
