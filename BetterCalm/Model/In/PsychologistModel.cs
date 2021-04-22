using System;
using System.ComponentModel.DataAnnotations;

namespace Model.In
{
    public class PsychologistModel
    {
        [Required]
        public string Name { get; set; }
        public string ConsultationMode { get; set; }
        public string Direction { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
