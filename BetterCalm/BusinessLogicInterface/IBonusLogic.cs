using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IBonusLogic
    {
        List<Pacient> GetAll();
        void Update(int pacientId, bool approved, double amount);
    }
}
