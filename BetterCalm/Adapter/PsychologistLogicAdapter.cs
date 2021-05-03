using System;
using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
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
            try
            {
                Psychologist psychologist = psychologistLogic.GetById(psychologistId);
                PsychologistBasicInfoModel psychologistToReturn = mapper.Map<PsychologistBasicInfoModel>(psychologist);
                return psychologistToReturn;
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.Message);
            }
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
            try
            {
                psychologistLogic.DeleteById(psychologistId);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.Message);
            }
        }

        public void Update(PsychologistModel psychologistModel)
        {
            try
            {
                Psychologist psychologistToUpdate = mapper.Map<Psychologist>(psychologistModel);
                psychologistLogic.Update(psychologistToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.Message);
            }
        }
    }
}
