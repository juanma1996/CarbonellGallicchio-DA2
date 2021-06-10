using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IBonusLogic
    {
        List<Pacient> GetAllGeneratedBonus();
        void Update(int pacientId, bool approved, double amount);
    }
}
