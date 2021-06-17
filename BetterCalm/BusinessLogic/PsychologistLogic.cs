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
        private readonly IRepository<Problematic> problematicRepository;
        private readonly IValidator<Psychologist> psychologistValidator;
        private readonly IAgendaLogic agendaLogic;
        private readonly IRepository<PsychologistProblematic> psychologistProblematicRepository;

        public PsychologistLogic(IRepository<Psychologist> psychologistRepository, IAgendaLogic agendaLogic,
            IValidator<Psychologist> psychologistValidator, IRepository<Problematic> problematicRepository,
            IRepository<PsychologistProblematic> psychologistProblematicRepository)
        {
            this.psychologistRepository = psychologistRepository;
            this.agendaLogic = agendaLogic;
            this.psychologistValidator = psychologistValidator;
            this.problematicRepository = problematicRepository;
            this.psychologistProblematicRepository = psychologistProblematicRepository;
        }

        private List<PsychologistProblematic> GetProblematicsByPsychologist(Psychologist psychologist)
        {
            var problematics = problematicRepository.GetAll(problematic => problematic.Psychologists.Any(a => a.PsychologistId == psychologist.Id));
            List<PsychologistProblematic> psychologistProblematics = new List<PsychologistProblematic>();
            problematics.ForEach(p => psychologistProblematics.Add(GetPsychologistProblematic(p, psychologist)));

            return psychologistProblematics;
        }
        private PsychologistProblematic GetPsychologistProblematic(Problematic problematic, Psychologist psychologist)
        {
            PsychologistProblematic psychologistProblematic = new PsychologistProblematic()
            {
                Problematic = problematic,
                Psychologist = psychologist
            };

            return psychologistProblematic;
        }
        private void DeletePsychologistProblematicRelations(Psychologist psychologist)
        {
            psychologistProblematicRepository.DeleteAll(p => p.PsychologistId.Equals(psychologist.Id));
        }
        private void CreatePsychologistProblematicRelations(List<PsychologistProblematic> problematics)
        {
            problematics.ForEach(p => psychologistProblematicRepository.Add(p));
        }

        public Psychologist GetById(int psychologistId)
        {
            Psychologist psychologist = psychologistRepository.GetById(psychologistId);
            psychologistValidator.Validate(psychologist);
            psychologist.Problematics = GetProblematicsByPsychologist(psychologist);
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
        public void Update(int id, Psychologist psychologist)
        {
            if (!psychologistRepository.Exists(a => a.Id == id))
            {
                throw new NullObjectException("There is no psychologist registered for the given data");
            }
            else
            {
                psychologist.Id = id;
                DeletePsychologistProblematicRelations(psychologist);
                psychologistRepository.Update(psychologist);
                CreatePsychologistProblematicRelations(psychologist.Problematics);
            }
        }
        public Psychologist GetAvailableByProblematicId(int problematicId)
        {
            return psychologistRepository.Get(p => p.Problematics.Exists(pr => pr.ProblematicId == problematicId));
        }
        public List<Psychologist> GetAllByProblematicId(int problematicId)
        {
            List<Psychologist> psychologists = null;
            bool existPsychologistByProblematic = psychologistRepository.Exists(p => p.Problematics.
                        Any(r => r.ProblematicId == problematicId));
            if (problematicId != 8 && existPsychologistByProblematic)
            {
                psychologists = psychologistRepository.GetAll(p => p.Problematics.Any(r => r.ProblematicId == problematicId));
            }
            else
            {
                psychologists = psychologistRepository.GetAll();
            }

            return psychologists;
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
        public List<Psychologist> GetAll()
        {
            List<Psychologist> psychologists = psychologistRepository.GetAll();
            return psychologists;
        }
    }
}
