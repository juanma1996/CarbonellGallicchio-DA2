using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class PsychologistModelValidator : IValidator<PsychologistModel>
    {
        public void Validate(PsychologistModel psychologistModel)
        {
            if (string.IsNullOrEmpty(psychologistModel.Name))
                throw new InvalidAttributeException("The psychologist's name can't be empty");
            if (string.IsNullOrEmpty(psychologistModel.ConsultationMode))
                throw new InvalidAttributeException("The psychologist's consultation mode can't be empty");
            if (!psychologistModel.ConsultationMode.Equals("Virtual") &&
                !psychologistModel.ConsultationMode.Equals("Presencial"))
                throw new InvalidAttributeException("The psychologist's consultation mode must be 'Virtual' or 'Presencial'");
            if (psychologistModel.ConsultationMode.Equals("Presencial") && string.IsNullOrEmpty(psychologistModel.Direction))
                throw new InvalidAttributeException("The psychologist's direction can't be empty");
            if (psychologistModel.Problematics is null || psychologistModel.Problematics.Count == 0)
                throw new AmountOfProblematicsException("The psychologist's problematics can't be zero");
            if (psychologistModel.Problematics.Count != 3)
                throw new AmountOfProblematicsException("The psychologist's problematics must be exactly three");
            if (psychologistModel.Fee != 500 &&
                psychologistModel.Fee != 750 &&
                psychologistModel.Fee != 1000 &&
                psychologistModel.Fee != 2000)
                throw new InvalidAttributeException("The psychologist fee value is invalid. Must be 500, 750, 1000 or 2000");
        }
    }
}
