using System;
using System.Collections.Generic;

namespace Model.Out
{
    public class PsychologistBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConsultationMode { get; set; }
        public string Direction { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ProblematicBasicInfoModel> Problematics { get; set; }
    }
}
