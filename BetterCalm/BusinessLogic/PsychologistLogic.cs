using System;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class PsychologistLogic
    {
        private readonly IRepository<Psychologist> psychologistRepository;
       
        public PsychologistLogic(IRepository<Psychologist> psychologistRepository)
        {
            this.psychologistRepository = psychologistRepository;
        }

        public Psychologist GetById(int psychologistId)
        {
            throw new NotImplementedException();
        }
    }
}
