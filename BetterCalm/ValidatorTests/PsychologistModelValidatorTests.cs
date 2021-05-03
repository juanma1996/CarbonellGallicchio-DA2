using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using System;
using System.Collections.Generic;
using System.Text;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class PsychologistModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithEmptyName()
        {
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = ""
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }
    }
}
