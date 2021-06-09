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

        public Consultation Add(Consultation consultationModel)
        {
            consultationModel.Psychologist = psychologistLogic.GetAvailableByProblematicIdAndDate(consultationModel.ProblematicId, DateTime.Now);
            Consultation consultation = consultationRepository.Add(consultationModel);
            if (consultation.Psychologist.ConsultationMode.Equals("Virtual"))
            {
                consultation.Psychologist.Direction = GenerateMeetingId();
            }
            consultation.Cost = (decimal)CalculateConsultationCost(consultation.Duration, consultation.Psychologist.Fee, 0);

            return consultation;
        }

        private string GenerateMeetingId()
        {
            string direction = "https://bettercalm.com.uy/meeting_id/";
            direction = direction + Guid.NewGuid().ToString();

            return direction;
        }

        private decimal CalculateConsultationCost(decimal duration, int fee, decimal bonification)
        {
            decimal cost = duration * fee;
            if (bonification != default)
            {
                cost = cost * bonification;
            }

            return cost;
        }
    }
}
