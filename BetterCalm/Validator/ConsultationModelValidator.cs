using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class ConsultationModelValidator : IValidator<ConsultationModel>
    {
        public void Validate(ConsultationModel consultationModel)
        {
            if (consultationModel.Pacient is null)
                throw new InvalidAttributeException("The pacient can't be empty");
            if (consultationModel.Duration != 1 &&
                consultationModel.Duration != (decimal)1.5 &&
                consultationModel.Duration != 2)
                throw new InvalidAttributeException("The consult duration value is invalid. Must be 1, 1.5 or 2");
        }
    }
}