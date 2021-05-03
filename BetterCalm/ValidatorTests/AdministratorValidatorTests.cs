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
    }
}
