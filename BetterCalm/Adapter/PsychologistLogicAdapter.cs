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
using ValidatorInterface;

namespace Adapter
{
    public class PsychologistLogicAdapter : IPsychologistLogicAdapter
    {
        private readonly IPsychologistLogic psychologistLogic;
        private readonly IMapper mapper;
        private readonly IValidator<PsychologistModel> psychologistModelValidator;
        public PsychologistLogicAdapter(IPsychologistLogic psychologistLogic, IModelMapper mapper,
            IValidator<PsychologistModel> psychologistModelValidator)
        {
            this.psychologistLogic = psychologistLogic;
            this.mapper = mapper.Configure();
            this.psychologistModelValidator = psychologistModelValidator;
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
                throw new NotFoundException(e.errorMessage);
            }
        }

        public PsychologistBasicInfoModel Add(PsychologistModel psychologistModel)
        {
            psychologistModelValidator.Validate(psychologistModel);
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
                throw new NotFoundException(e.errorMessage);
            }
        }

        public void Update(PsychologistModel psychologistModel)
        {
            try
            {
                psychologistModelValidator.Validate(psychologistModel);
                Psychologist psychologistToUpdate = mapper.Map<Psychologist>(psychologistModel);
                psychologistLogic.Update(psychologistToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
    }
}
