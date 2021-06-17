using Model.In;
using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface IBonusLogicAdapter
    {
        List<BonusBasicInfoModel> GetAll();
        void Update(int id, BonusModel bonusModel);
    }
}
