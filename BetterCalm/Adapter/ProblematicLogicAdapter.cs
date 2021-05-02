using System;
using System.Collections.Generic;
using Adapter.Mapper;
using AdapterInterface;
using AutoMapper;
using BusinessLogicInterface;
using Model.Out;

namespace Adapter
{
    public class ProblematicLogicAdapter : IProblematicLogicAdapter
    {
        private readonly IProblematicLogic problematicLogic;
        private readonly IMapper mapper;
        public ProblematicLogicAdapter(IProblematicLogic problematicLogic, IModelMapper mapper)
        {
            this.problematicLogic = problematicLogic;
            this.mapper = mapper.Configure();
        }

        public List<ProblematicBasicInfoModel> GetAll()
        {
            List<ProblematicBasicInfoModel> problematics = mapper.Map<List<ProblematicBasicInfoModel>>(problematicLogic.GetAll());
            return problematics;
        }
    }
}
