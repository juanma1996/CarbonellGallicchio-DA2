using BusinessExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class AdministratorValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestNullAdministrator()
        {
            Administrator administrator = null;
            AdministratorValidator validator = new AdministratorValidator();

            validator.Validate(administrator);
        }

        [TestMethod]
        public void TestAdministratorIsCorrect()
        {
            Administrator administrator = new Administrator
            {
                Name = "Juan",
                Email = "oneMail@gmail.com",
                Password = "password",
            };
            AdministratorValidator validator = new AdministratorValidator();

            validator.Validate(administrator);
        }
    }
}
