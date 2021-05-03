using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using System;
using System.Collections.Generic;
using System.Text;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class SessionModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestSessionModelWithEmptyEmail()
        {
            SessionModel sessionModel = new SessionModel
            {
                Email = "",
                Password = "password"
            };
            SessionModelValidator validator = new SessionModelValidator();

            validator.Validate(sessionModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestSessionModelWithEmptyPassword()
        {
            SessionModel sessionModel = new SessionModel
            {
                Email = "oneMail",
                Password = ""
            };
            SessionModelValidator validator = new SessionModelValidator();

            validator.Validate(sessionModel);
        }

        [TestMethod]
        public void TestSessionModelIsCorrect()
        {
            SessionModel sessionModel = new SessionModel
            {
                Email = "oneMail",
                Password = "password"
            };
            SessionModelValidator validator = new SessionModelValidator();

            validator.Validate(sessionModel);
        }
    }
}
