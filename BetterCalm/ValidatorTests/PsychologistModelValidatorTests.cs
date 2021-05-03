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

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithEmptyConsultationMode()
        {
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = ""
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithEmptyDirection()
        {
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "One mode",
                Direction = ""
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithZeroProblematics()
        {
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "One mode",
                Direction = "Direction",
                Problematics = new List<ProblematicModel>()
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }
    }
}
