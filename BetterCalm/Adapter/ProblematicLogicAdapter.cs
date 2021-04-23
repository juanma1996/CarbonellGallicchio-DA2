using System;
using System.Collections.Generic;
using AdapterInterface;
using Model.Out;

namespace Adapter
{
    public class ProblematicLogicAdapter : IProblematicLogicAdapter
    {
        public ProblematicLogicAdapter()
        {
        }

        public List<ProblematicBasicInfoModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
