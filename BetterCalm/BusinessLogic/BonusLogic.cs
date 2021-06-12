using BusinessExceptions;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;
using ValidatorInterface;

namespace BusinessLogic
{
    public class BonusLogic : IBonusLogic
    {
        private IRepository<Pacient> pacientRepository;
        private readonly IValidator<Pacient> pacientValidator;

        public BonusLogic(IRepository<Pacient> pacientRepository, IValidator<Pacient> pacientValidator)
        {
            this.pacientRepository = pacientRepository;
            this.pacientValidator = pacientValidator;
        }

        public List<Pacient> GetAllGeneratedBonus()
        {
            List<Pacient> pacients = pacientRepository.GetAll(p => p.GeneratedBonus);
            return pacients;
        }

        public void Update(int pacientId, bool approved, double amount)
        {
            Pacient pacient = pacientRepository.Get(p => p.Id == pacientId);
            pacientValidator.Validate(pacient);
            if (!pacient.GeneratedBonus)
                throw new NotGeneratedBonusException("Patient for the data provided did not generate a bonus");
            AdministrateBonus(pacient, amount, approved);
            pacientRepository.Update(pacient);
        }

        private void AdministrateBonus(Pacient pacient, double amount, bool approved)
        {
            if (approved)
            {
                ApproveBonus(pacient, amount);
            }
            else if (!approved)
            {
                DenyBonus(pacient);
            }
        }

        private void ApproveBonus(Pacient pacient, double amount)
        {
            pacient.BonusAmount = (decimal)(1 - amount);
            pacient.GeneratedBonus = false;
            pacient.BonusApproved = true;
        }

        private void DenyBonus(Pacient pacient)
        {
            pacient.BonusAmount = 0;
            pacient.GeneratedBonus = false;
            pacient.ConsultationsQuantity = 0;
            pacient.BonusApproved = false;
        }
    }
}
