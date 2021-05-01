using System;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class ConsultationLogic : IConsultationLogic
    {
        private readonly IRepository<Consultation> consultationRepository;
        public ConsultationLogic(IRepository<Consultation> consultationRepository)
        {
            this.consultationRepository = consultationRepository;
        }

        public Psychologist Add(Consultation consultationModel)
        {
            throw new NotImplementedException();
        }
    }
}
