using AdapterExceptions;
using Model.In;
using ValidatorInterface;

namespace Validator
{
    public class BonusModelValidator : IValidator<BonusModel>
    {
        public void Validate(BonusModel bonusModel)
        {
            if (bonusModel.Amount != 0.15 && bonusModel.Amount != 0.25 && bonusModel.Amount != 0.50)
                throw new InvalidAttributeException("Amount value is invalid. Must be 15, 25 or 50");
        }
    }
}
