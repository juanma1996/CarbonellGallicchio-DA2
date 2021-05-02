using System;
using Adapter.Mapper;
using AdapterInterface;
using AutoMapper;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter
{
    public class PsychologistLogicAdapter : IPsychologistLogicAdapter
    {
        private readonly IPsychologistLogic psychologistLogic;
        private readonly IMapper mapper;
        public PsychologistLogicAdapter(IPsychologistLogic psychologistLogic, IModelMapper mapper)
        {
            this.psychologistLogic = psychologistLogic;
            this.mapper = mapper.Configure();
        }

        public PsychologistBasicInfoModel GetById(int psychologistId)
        {
            Psychologist psychologist = psychologistLogic.GetById(psychologistId);
            PsychologistBasicInfoModel psychologistToReturn = mapper.Map<PsychologistBasicInfoModel>(psychologist);
            return psychologistToReturn;
        }

        public PsychologistBasicInfoModel Add(PsychologistModel psychologistModel)
        {
            Psychologist psychologistIn = mapper.Map<Psychologist>(psychologistModel);
            Psychologist psychologistOut = psychologistLogic.Add(psychologistIn);
            PsychologistBasicInfoModel psychologistToReturn = mapper.Map<PsychologistBasicInfoModel>(psychologistOut);
            return psychologistToReturn;
        }

        public void Delete(int psychologistId)
        {
            psychologistLogic.DeleteById(psychologistId);
        }

        public void Update(PsychologistModel psychologistModel)
        {
            Psychologist psychologistToUpdate = mapper.Map<Psychologist>(psychologistModel);
            psychologistLogic.Update(psychologistToUpdate);
        }
    }
}
