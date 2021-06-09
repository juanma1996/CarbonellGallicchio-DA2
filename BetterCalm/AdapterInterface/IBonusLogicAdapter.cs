using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface IBonusLogicAdapter
    {
        List<BonusBasicInfoModel> GetAll();
    }
}
