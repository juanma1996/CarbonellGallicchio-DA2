using BusinessExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using ValidatorInterface;

namespace Validator
{
    public class PacientValidator : IValidator<Pacient>
    {
        public void Validate(Pacient pacient)
        {
            if (pacient is null)
                throw new NullObjectException("Pacient not exists for the given data");
        }
    }
}
