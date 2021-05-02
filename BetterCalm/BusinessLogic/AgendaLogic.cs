using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;

namespace BusinessLogic
{
    public class AgendaLogic : IAgendaLogic
    {
        private IRepository<Agenda> @object;

        public AgendaLogic(IRepository<Agenda> @object)
        {
            this.@object = @object;
        }

        public Agenda GetAgendaByPsychologistIdAndDate(int psychologistId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
