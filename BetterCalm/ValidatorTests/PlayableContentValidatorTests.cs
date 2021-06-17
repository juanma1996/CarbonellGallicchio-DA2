using BusinessExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class PlayableContentValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestNullAudioContent()
        {
            PlayableContent audioContent = null;
            PlayableContentValidator validator = new PlayableContentValidator();

            validator.Validate(audioContent);
        }

        [TestMethod]
        public void TestAudioContentIsCorrect()
        {
            PlayableContent audioContent = new PlayableContent
            {
                Name = "Juan"
            };
            PlayableContentValidator validator = new PlayableContentValidator();

            validator.Validate(audioContent);
        }
    }
}
