using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;

namespace BusinessLogic
{
    public class AgendaLogic : IAgendaLogic
    {
        private IRepository<Agenda> agendaRepository;

        public AgendaLogic(IRepository<Agenda> agendaRepository)
        {
            this.agendaRepository = agendaRepository;
        }

        public Agenda GetAgendaByPsychologistIdAndDate(int psychologistId, DateTime date)
        {
            return agendaRepository.Get(a => a.Psychologist.Id == psychologistId && a.Date.Date == date.Date);
        }

        public Agenda Add(Psychologist psychologistId, DateTime date)
        {
            Agenda newAgenda = new Agenda()
            {
                Psychologist = psychologistId,
                IsAvaible = true,
                Date = date,
            };
            return agendaRepository.Add(newAgenda);
        }

        public void Update(Agenda agendaToUse)
        {
            agendaRepository.Update(agendaToUse);
        }

        public Agenda Assign(Agenda agendaToReturn)
        {
            agendaToReturn.Count++;
            agendaToReturn.IsAvaible = agendaToReturn.Count < 5;
            return agendaToReturn;
        }
    }
}
