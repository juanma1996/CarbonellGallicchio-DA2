using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class AudioContentModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestAdministratorModelWithEmptyName()
        {
            AudioContentModel administratorModel = new AudioContentModel
            {
                Name = ""
            };
            AudioContentModelValidator validator = new AudioContentModelValidator();

            validator.Validate(administratorModel);
        }
    }
}
