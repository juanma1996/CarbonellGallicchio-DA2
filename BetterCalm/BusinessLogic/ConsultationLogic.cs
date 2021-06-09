using System;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class ConsultationLogic : IConsultationLogic
    {
        private readonly IRepository<Consultation> consultationRepository;
        private readonly IRepository<Pacient> pacientRepository;
        private readonly IPsychologistLogic psychologistLogic;
        public ConsultationLogic(IRepository<Consultation> consultationRepository, IPsychologistLogic psychologistLogic, IRepository<Pacient> pacientRepository)
        {
            this.consultationRepository = consultationRepository;
            this.psychologistLogic = psychologistLogic;
            this.pacientRepository = pacientRepository;
        }

        public Consultation Add(Consultation consultationModel)
        {
            consultationModel.Psychologist = psychologistLogic.GetAvailableByProblematicIdAndDate(consultationModel.ProblematicId, DateTime.Now);
            consultationModel.Pacient = GetPacientByEmail(consultationModel.Pacient);
            Consultation consultation = consultationRepository.Add(consultationModel);
            if (consultation.Psychologist.ConsultationMode.Equals("Virtual"))
            {
                consultation.Psychologist.Direction = GenerateMeetingId();
            }
            decimal pacientBonification = GetPacientBonification(consultationModel.Pacient);
            consultation.Cost = (decimal)CalculateConsultationCost(consultation.Duration, consultation.Psychologist.Fee, pacientBonification);

            return consultation;
        }

        private decimal GetPacientBonification(Pacient pacient)
        {
            decimal pacientBonification = 0;
            if (pacient.BonificationApproved)
            {
                pacientBonification = pacient.BonificationAmount;
            }

            return pacientBonification;
        }

        private Pacient GetPacientByEmail(Pacient pacient)
        {
            Pacient pacientByEmail = pacientRepository.Get(p => p.Email.Equals(pacient.Email));
            if (pacientByEmail is null)
            {
                pacientByEmail = pacient;
            }

            return pacientByEmail;
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
