using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using System;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class ConsultationValidatorTests
    {
        [TestMethod]
        public void TestConsultationModelOk()
        {
            ConsultationModel consultationModel = new ConsultationModel
            {
                ProblematicId = 1,
                Pacient = new PacientModel()
                {
                    Name = "Juan",
                    Surname = "Gallicchio",
                    BirthDate = DateTime.Now,
                    Cellphone = "097654123",
                    Email = "juan@gmail.com"
                },
                Duration = 1
            };
            ConsultationModelValidator validator = new ConsultationModelValidator();

            validator.Validate(consultationModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestConsultationModelNullPacient()
        {
            ConsultationModel pacientModel = new ConsultationModel
            {
                ProblematicId = 1,
                Pacient = null
            };
            ConsultationModelValidator validator = new ConsultationModelValidator();

            validator.Validate(pacientModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestConsultationModelInvalidDuration()
        {
            ConsultationModel consultationModel = new ConsultationModel
            {
                ProblematicId = 1,
                Pacient = new PacientModel
                {
                    Name = "Juan",
                    Surname = "Perez",
                    BirthDate = new DateTime(1996, 12, 05),
                    Email = "Juan@gmail.com",
                    Cellphone = "098342972"
                },
                Duration = 5
            };
            ConsultationModelValidator validator = new ConsultationModelValidator();

            validator.Validate(consultationModel);
        }
    }
}
