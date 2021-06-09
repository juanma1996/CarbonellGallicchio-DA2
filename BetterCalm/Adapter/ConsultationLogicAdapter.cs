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
    public class ConsultationLogicAdapter : IConsultationLogicAdapter
    {
        private readonly IConsultationLogic consultationLogic;
        private readonly IMapper mapper;
        private readonly IValidator<ConsultationModel> consultationModelValidator;
        private readonly IValidator<PacientModel> pacientModelValidator;
        public ConsultationLogicAdapter(IConsultationLogic consultationLogic, IModelMapper mapper,
            IValidator<ConsultationModel> consultationModelValidator, IValidator<PacientModel> pacientModelValidator)
        {
            this.consultationLogic = consultationLogic;
            this.mapper = mapper.Configure();
            this.consultationModelValidator = consultationModelValidator;
            this.pacientModelValidator = pacientModelValidator;
        }

        public ConsultationBasicInfoModel Add(ConsultationModel consultationModel)
        {
            try
            {
                consultationModelValidator.Validate(consultationModel);
                pacientModelValidator.Validate(consultationModel.Pacient);
                Consultation consultation = mapper.Map<Consultation>(consultationModel);
                Psychologist psychologist = consultationLogic.Add(consultation);
                return mapper.Map<ConsultationBasicInfoModel>(psychologist);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
    }
}
