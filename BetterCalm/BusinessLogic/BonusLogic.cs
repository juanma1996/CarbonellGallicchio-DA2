using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class BonusLogic : IBonusLogic
    {
        private IRepository<Pacient> pacientRepository;

        public BonusLogic(IRepository<Pacient> pacientRepository)
        {
            this.pacientRepository = pacientRepository;
        }

        public List<Pacient> GetAllGeneratedBonus()
        {
            List<Pacient> pacients = pacientRepository.GetAll(p => p.BonusApproved);
            return pacients;
        }

        public void Update(int pacientId, bool approved, double amount)
        {
            Pacient pacient = pacientRepository.Get(p => p.Id == pacientId);
            pacient.BonusApproved = approved;
            pacient.BonusAmount = (decimal)amount;
            pacientRepository.Update(pacient);
        }
    }
}
