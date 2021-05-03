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
        [ExpectedException(typeof(InvalidNameException))]
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
    }
}
