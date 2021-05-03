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
    public class ConsultationLogicAdapter : IConsultationLogicAdapter
    {
        private readonly IConsultationLogic consultationLogic;
        private readonly IMapper mapper;
        public ConsultationLogicAdapter(IConsultationLogic consultationLogic, IModelMapper mapper)
        {
            this.consultationLogic = consultationLogic;
            this.mapper = mapper.Configure();
        }

        public PsychologistBasicInfoModel Add(ConsultationModel consultationModel)
        {
            try
            {
                Consultation consultation = mapper.Map<Consultation>(consultationModel);
                Psychologist psychologist = consultationLogic.Add(consultation);
                return mapper.Map<PsychologistBasicInfoModel>(psychologist);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.Message);
            }
        }
    }
}
