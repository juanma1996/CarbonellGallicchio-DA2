using BusinessExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class PsychologistValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestNullPsychologist()
        {
            Psychologist psychologist = null;
            PsychologistValidator validator = new PsychologistValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        public void TestPsychologistIsCorrect()
        {
            Psychologist psychologist = new Psychologist()
            {
                Id = 1
            };
            PsychologistValidator validator = new PsychologistValidator();

            validator.Validate(psychologist);
        }
    }
}
