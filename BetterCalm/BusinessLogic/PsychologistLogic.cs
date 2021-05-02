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

        public PsychologistLogic(IRepository<Psychologist> psychologistRepository)
        {
            this.psychologistRepository = psychologistRepository;
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

        public List<Psychologist> GetAvailablesByProblematicId(int problematicId)
        {
            return psychologistRepository.GetAll(p => p.Problematics.Any(r => r.ProblematicId == problematicId));
        }
    }
}
