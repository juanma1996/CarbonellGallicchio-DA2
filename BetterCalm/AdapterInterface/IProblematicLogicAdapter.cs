using System;
using System.Collections.Generic;
using Model.Out;

namespace AdapterInterface
{
    public interface IProblematicLogicAdapter
    {
        List<ProblematicBasicInfoModel> GetAll();
    }
}
