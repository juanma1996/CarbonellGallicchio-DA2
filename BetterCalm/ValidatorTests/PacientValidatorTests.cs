using BusinessExceptions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class PacientValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestNullPacient()
        {
            Pacient pacient = null;
            PacientValidator validator = new PacientValidator();

            validator.Validate(pacient);
        }
    }
}
