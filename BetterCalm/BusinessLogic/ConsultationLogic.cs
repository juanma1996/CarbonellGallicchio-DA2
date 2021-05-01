using System;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class ConsultationLogic : IConsultationLogic
    {
        private readonly IRepository<Consultation> consultationRepository;
        private readonly IPsychologistLogic psychologistLogic;
        public ConsultationLogic(IRepository<Consultation> consultationRepository, IPsychologistLogic psychologistLogic)
        {
            this.consultationRepository = consultationRepository;
            this.psychologistLogic = psychologistLogic;
        }

        public Psychologist Add(Consultation consultationModel)
        {
            consultationModel.Psychologist = psychologistLogic.GetAvailableByProblematicId(consultationModel.ProblematicId);
            Consultation consultation = consultationRepository.Add(consultationModel);
            return consultation.Psychologist;
        }
    }
}
