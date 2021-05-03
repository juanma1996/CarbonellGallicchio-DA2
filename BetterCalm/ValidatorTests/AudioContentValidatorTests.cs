using BusinessExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class AudioContentValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestAdministratorModelWithEmptyName()
        {
            AudioContent administratorModel = null;
            AudioContentValidator validator = new AudioContentValidator();

            validator.Validate(administratorModel);
        }
    }
}
