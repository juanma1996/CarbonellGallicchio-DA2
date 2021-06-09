using AdapterInterface;
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
    }
}
