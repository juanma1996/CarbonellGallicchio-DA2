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
            return agendaRepository.Get(a => a.Psychologist.Id == psychologistId && a.Date == date);
        }

        public Agenda Add(int psychologistId, DateTime date)
        {
            Agenda newAgenda = new Agenda()
            {
                Psychologist = new Psychologist { Id = psychologistId },
                IsAvaible = true,
                Date = date,
            };
            return agendaRepository.Add(newAgenda);
        }
    }
}
