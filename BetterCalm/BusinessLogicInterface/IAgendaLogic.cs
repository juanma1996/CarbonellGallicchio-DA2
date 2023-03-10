using Domain;
using System;

namespace BusinessLogicInterface
{
    public interface IAgendaLogic
    {
        Agenda GetAgendaByPsychologistIdAndDate(int psychologistId, DateTime date);
        Agenda Add(Psychologist psychologistId, DateTime date);
        void Update(Agenda agendaToUse);
        Agenda Assign(Agenda agendaToReturn);
    }
}
