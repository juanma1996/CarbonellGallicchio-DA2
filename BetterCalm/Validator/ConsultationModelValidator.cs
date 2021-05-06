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
        }
    }
}