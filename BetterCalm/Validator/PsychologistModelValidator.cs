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
                throw new InvalidAttributeException("The psychologist's name can't be empty");
            if (string.IsNullOrEmpty(psychologistModel.ConsultationMode))
                throw new InvalidAttributeException("The psychologist's consultation mode can't be empty");
            if (string.IsNullOrEmpty(psychologistModel.Direction))
                throw new InvalidAttributeException("The psychologist's direction can't be empty");
            if (psychologistModel.Problematics == null || psychologistModel.Problematics.Count == 0)
                throw new InvalidAttributeException("The psychologist's problematics can't be zero");
        }
    }
}
