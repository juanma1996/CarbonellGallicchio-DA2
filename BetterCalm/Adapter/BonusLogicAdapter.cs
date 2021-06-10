using AdapterInterface;
using Model.In;
using Model.Out;
using System.Collections.Generic;

namespace Adapter
{
    public class BonusLogicAdapter : IBonusLogicAdapter
    {
        public List<BonusBasicInfoModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(BonusModel bonusModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
