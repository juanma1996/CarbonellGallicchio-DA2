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

        private decimal CalculateBonus(Pacient pacient)
        {
            decimal pacientBonus = 0;
            if (pacient.BonusApproved)
            {
                pacientBonus = ApplyBonus(pacient);
            }
            else
            {
                CalculateConsultationQuantity(pacient);
            }

            return pacientBonus;
        }
        private void CalculateConsultationQuantity(Pacient pacient)
        {
            pacient.ConsultationsQuantity++;
            if (pacient.ConsultationsQuantity >= 5)
            {
                pacient.GeneratedBonus = true;
            }
        }
        private decimal ApplyBonus(Pacient pacient)
        {
            decimal pacientBonus = pacient.BonusAmount;
            pacient.ConsultationsQuantity = 0;
            pacient.GeneratedBonus = false;
            pacient.BonusApproved = false;

            return pacientBonus;
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
        private decimal CalculateConsultationCost(decimal duration, int fee, decimal bonus)
        {
            decimal cost = duration * fee;
            if (bonus != default)
            {
                cost *= bonus;
            }

            return cost;
        }

        public Consultation Add(Consultation consultationModel)
        {

            consultationModel.Psychologist = psychologistLogic.GetAvailableByProblematicIdAndDate(consultationModel.ProblematicId, DateTime.Now);
            Pacient pacient = GetPacientByEmail(consultationModel.Pacient);
            decimal pacientBonus = CalculateBonus(pacient);
            bool existPacient = pacientRepository.Exists(p => p.Email.Equals(pacient.Email));
            if (existPacient)
            {
                pacientRepository.Update(pacient);
            }
            else
            {
                pacientRepository.Add(pacient);
            }
            consultationModel.Pacient = pacient;
            Consultation consultation = consultationRepository.Add(consultationModel);
            if (consultation.Psychologist.ConsultationMode.Equals("Virtual"))
            {
                consultation.Psychologist.Direction = GenerateMeetingId();
            }
            consultation.Cost = CalculateConsultationCost(consultation.Duration, consultation.Psychologist.Fee, pacientBonus);

            return consultation;
        }
    }
}
