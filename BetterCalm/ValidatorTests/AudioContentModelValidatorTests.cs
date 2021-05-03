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
        public void TestAudioContentModelWithEmptyName()
        {
            AudioContentModel audioContentModel = new AudioContentModel
            {
                Name = ""
            };
            AudioContentModelValidator validator = new AudioContentModelValidator();

            validator.Validate(audioContentModel);
        }

        [TestMethod]
        public void TestAudioContentModelIsCorrect()
        {
            AudioContentModel audioContentModel = new AudioContentModel
            {
                Name = "Juan"
            };
            AudioContentModelValidator validator = new AudioContentModelValidator();

            validator.Validate(audioContentModel);
        }
    }
}
