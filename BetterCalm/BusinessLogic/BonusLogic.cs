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
            pacient.BonusApproved = approved;
            if (approved)
            {
                pacient.BonusAmount = (decimal)(1 - amount);
            }
            else
            {
                pacient.BonusAmount = 0;
                pacient.GeneratedBonus = false;
                pacient.ConsultationsQuantity = 0;
            }
            pacientRepository.Update(pacient);
        }
    }
}
