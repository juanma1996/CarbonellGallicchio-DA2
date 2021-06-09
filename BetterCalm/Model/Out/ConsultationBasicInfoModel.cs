using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Out
{
    public class ConsultationBasicInfoModel
    {
        public decimal Cost { get; set; }
        public PsychologistBasicInfoModel Psychologist { get; set; }
    }
}
