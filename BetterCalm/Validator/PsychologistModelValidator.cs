using AdapterExceptions;
using Model.In;
using System;
using System.Collections.Generic;
using System.Text;
using ValidatorInterface;

namespace Validator
{
    public class PsychologistModelValidator : IValidator<PsychologistModel>
    {
        public void Validate(PsychologistModel psychologistModel)
        {
            if (string.IsNullOrEmpty(psychologistModel.Name))
                throw new InvalidAttributeException("The psychologist name can't be empty");
        }
    }
}
