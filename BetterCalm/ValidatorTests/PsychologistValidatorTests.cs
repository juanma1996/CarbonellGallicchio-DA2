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
    }
}
