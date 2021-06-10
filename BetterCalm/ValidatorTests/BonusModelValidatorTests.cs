using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class BonusModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestApproveBonusInvalidAmount()
        {
            BonusModel bonusModel = new BonusModel()
            {
                PacientId = 1,
                Approved = true,
                Amount = 5
            };
            BonusModelValidator validator = new BonusModelValidator();

            validator.Validate(bonusModel);
        }
    }
}
