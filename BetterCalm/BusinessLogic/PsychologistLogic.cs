using System;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class PsychologistLogic : IPsychologistLogic
    {
        private readonly IRepository<Psychologist> psychologistRepository;
       
        public PsychologistLogic(IRepository<Psychologist> psychologistRepository)
        {
            this.psychologistRepository = psychologistRepository;
        }

        public Psychologist GetById(int psychologistId)
        {
            return psychologistRepository.GetById(psychologistId);
        }

        public Psychologist Add(Psychologist psycologist)
        {
            return psychologistRepository.Add(psycologist);
        }

        public void DeleteById(int psychologistId)
        {
            Psychologist psychologist = psychologistRepository.GetById(psychologistId);
            psychologistRepository.Delete(psychologist);
        }

        public void Update(Psychologist psychologist)
        {
            throw new NotImplementedException();
        }
    }
}
