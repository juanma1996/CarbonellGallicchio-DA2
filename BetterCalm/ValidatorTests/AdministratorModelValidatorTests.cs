using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class AdministratorModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithEmptyName()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            AdministratorModelValidator validator = new AdministratorModelValidator();

            validator.Validate(administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithEmptyPassword()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "",
            };
            AdministratorModelValidator validator = new AdministratorModelValidator();

            validator.Validate(administratorModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithEmptyEmail()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "",
                Password = "password",
            };
            AdministratorModelValidator validator = new AdministratorModelValidator();

            validator.Validate(administratorModel);
        }

        [TestMethod]
        public void TestAdministratorModelIsCorrect()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "oneMail@gmail.com",
                Password = "password",
            };
            AdministratorModelValidator validator = new AdministratorModelValidator();

            validator.Validate(administratorModel);
        }
    }
}
