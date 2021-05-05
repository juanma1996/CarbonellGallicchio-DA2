using System;
using System.Collections.Generic;
using System.Linq;
using BusinessExceptions;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using ValidatorInterface;

namespace BusinessLogic
{
    public class PsychologistLogic : IPsychologistLogic
    {
        private readonly IRepository<Psychologist> psychologistRepository;
        private readonly IValidator<Psychologist> psychologistValidator;
        private readonly IAgendaLogic agendaLogic;

        public PsychologistLogic(IRepository<Psychologist> psychologistRepository, IAgendaLogic agendaLogic,
            IValidator<Psychologist> psychologistValidator)
        {
            this.psychologistRepository = psychologistRepository;
            this.agendaLogic = agendaLogic;
            this.psychologistValidator = psychologistValidator;
        }

        public Psychologist GetById(int psychologistId)
        {
            Psychologist psychologist = psychologistRepository.GetById(psychologistId);
            psychologistValidator.Validate(psychologist);
            return psychologist;
        }

        public Psychologist Add(Psychologist psycologist)
        {
            psycologist.CreationDate = DateTime.Now;
            return psychologistRepository.Add(psycologist);
        }

        public void DeleteById(int psychologistId)
        {
            Psychologist psychologist = GetById(psychologistId);
            psychologistRepository.Delete(psychologist);
        }

        public void Update(Psychologist psychologist)
        {
            if (!psychologistRepository.Exists(a => a.Id == psychologist.Id))
            {
                throw new NullObjectException("There is no psychologist registered for the given data");
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
            int daysToAdd = 1;
            List<Agenda> agendas = new List<Agenda>();
            List<Psychologist> psychologists = GetAllByProblematicId(problematicId);
            if (psychologists is null || psychologists.Count == 0)
            {
                throw new NullObjectException("There is no psychologist registered for the given data");
            }
            else
            {
                psychologistValidator.Validate(psychologists.First());
            }
            while (agendas.Count == 0)
            {
                if (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
                {
                    psychologists.ForEach(item =>
                            {
                                Agenda agenda = agendaLogic.GetAgendaByPsychologistIdAndDate(item.Id, date);
                                if (agenda is null)
                                {
                                    agenda = agendaLogic.Add(item, date);
                                }
                                if (agenda.IsAvaible)
                                {
                                    agendas.Add(agenda);
                                }
                            });
                }
                date = date.AddDays(daysToAdd);
            }
            Agenda agendaToUse = agendas.OrderBy(a => a.Psychologist.CreationDate).First();
            agendaLogic.Assign(agendaToUse);
            agendaLogic.Update(agendaToUse);
            return agendaToUse.Psychologist;
        }
    }
}
