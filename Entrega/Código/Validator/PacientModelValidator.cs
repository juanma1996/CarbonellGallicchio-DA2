using AdapterExceptions;
using Model.In;
using System;
using System.Collections.Generic;
using System.Text;
using ValidatorInterface;

namespace Validator
{
    public class PacientModelValidator : IValidator<PacientModel>
    {
        public void Validate(PacientModel pacientModel)
        {
            if (string.IsNullOrEmpty(pacientModel.Name))
                throw new InvalidAttributeException("The pacient's name can't be empty");
            if (string.IsNullOrEmpty(pacientModel.Surname))
                throw new InvalidAttributeException("The pacient's surname can't be empty");
            if (string.IsNullOrEmpty(pacientModel.Email))
                throw new InvalidAttributeException("The pacient's email can't be empty");
            if (string.IsNullOrEmpty(pacientModel.Cellphone))
                throw new InvalidAttributeException("The pacient's cellphone can't be empty");
        }
    }
}
