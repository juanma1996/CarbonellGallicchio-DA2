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
            ConsultationModel pacientModel = new ConsultationModel
            {
                ProblematicId = 1,
                Pacient = new PacientModel()
                {
                    Name = "Juan",
                    Surname = "Gallicchio",
                    BirthDate = DateTime.Now,
                    Cellphone = "097654123",
                    Email = "juan@gmail.com"
                }
            };
            ConsultationModelValidator validator = new ConsultationModelValidator();

            validator.Validate(pacientModel);
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
    }
}
