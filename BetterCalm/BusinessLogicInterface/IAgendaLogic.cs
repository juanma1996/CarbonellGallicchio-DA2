using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicInterface
{
    public interface IAgendaLogic
    {
        Agenda GetAgendaByPsychologistIdAndDate(int psychologistId, DateTime date);
        Agenda Add(int psychologistId, DateTime date);
        void Update(Agenda agendaToUse);
    }
}
