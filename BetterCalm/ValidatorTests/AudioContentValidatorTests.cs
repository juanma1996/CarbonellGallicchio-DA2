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
        public void TestNullAudioContent()
        {
            AudioContent audioContent = null;
            AudioContentValidator validator = new AudioContentValidator();

            validator.Validate(audioContent);
        }

        [TestMethod]
        public void TestAudioContentIsCorrect()
        {
            AudioContent audioContent = new AudioContent
            {
                Name = "Juan"
            };
            AudioContentValidator validator = new AudioContentValidator();

            validator.Validate(audioContent);
        }
    }
}
