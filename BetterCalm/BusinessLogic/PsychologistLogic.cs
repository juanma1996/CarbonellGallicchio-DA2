using System;
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
    }
}
