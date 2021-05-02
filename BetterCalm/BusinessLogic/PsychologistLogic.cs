using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class PsychologistLogic : IPsychologistLogic
    {
        private readonly IRepository<Psychologist> psychologistRepository;
        private readonly Validation validation = new Validation();
        private readonly IAgendaLogic agendaLogic;

        public PsychologistLogic(IRepository<Psychologist> psychologistRepository, IAgendaLogic agendaLogic)
        {
            this.psychologistRepository = psychologistRepository;
            this.agendaLogic = agendaLogic;
        }

        public Psychologist GetById(int psychologistId)
        {
            Psychologist psychologist = psychologistRepository.GetById(psychologistId);
            validation.Validate(psychologist);
            return psychologist;
        }

        public Psychologist Add(Psychologist psycologist)
        {
            psycologist.CreationDate = DateTime.Today;
            return psychologistRepository.Add(psycologist);
        }

        public void DeleteById(int psychologistId)
        {
            Psychologist psychologist = psychologistRepository.GetById(psychologistId);
            validation.Validate(psychologist);
            psychologistRepository.Delete(psychologist);
        }

        public void Update(Psychologist psychologist)
        {
            if (!psychologistRepository.Exists(a => a.Id == psychologist.Id))
            {
                validation.NullObjectException();
            }
            else
            {
                psychologistRepository.Update(psychologist);
            }
        }

        public Psychologist GetAvailableByProblematicId(int problematicId)
        {
            return psychologistRepository.Get(p => p.Problematics.Exists(pr => pr.ProblematicId == problematicId));
        }

        public List<Psychologist> GetAllByProblematicId(int problematicId)
        {
            return psychologistRepository.GetAll(p => p.Problematics.Any(r => r.ProblematicId == problematicId));
        }

        public Psychologist GetAvailableByProblematicIdAndDate(int problematicId, DateTime date)
        {
            List<Agenda> agendas = new List<Agenda>();
            List<Psychologist> psychologists = GetAllByProblematicId(problematicId);
            validation.ValidateList(psychologists);
            while (agendas.Count == 0)
            {
                if (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
                {
                    psychologists.ForEach(item =>
                            {
                                Agenda agenda = agendaLogic.GetAgendaByPsychologistIdAndDate(item.Id, date);
                                if (agenda is null)
                                {
                                    agenda = agendaLogic.Add(item.Id, date);
                                }
                                if (agenda.IsAvaible)
                                {
                                    agendas.Add(agenda);
                                }
                            });
                }
                date = date.AddDays(1);
            }
            Agenda agendaToUse = agendas.OrderBy(a => a.Psychologist.CreationDate).First();
            agendaLogic.Assign(agendaToUse);
            agendaLogic.Update(agendaToUse);
            return agendaToUse.Psychologist;
        }
    }
}
