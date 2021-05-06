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
    public class PacientModelValidatorTests
    {
        [TestMethod]
        public void TestPacientModelOk()
        {
            PacientModel pacientModel = new PacientModel
            {
                Name = "Juan",
                Surname = "Gallicchio",
                BirthDate = DateTime.Now,
                Cellphone = "097654123",
                Email = "juan@gmail.com"
            };
            PacientModelValidator validator = new PacientModelValidator();

            validator.Validate(pacientModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPacientModelWithEmptyName()
        {
            PacientModel pacientModel = new PacientModel
            {
                Name = "",
                Surname = "Gallicchio",
                BirthDate = DateTime.Now,
                Cellphone = "097654123",
                Email = "juan@gmail.com"
            };
            PacientModelValidator validator = new PacientModelValidator();

            validator.Validate(pacientModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPacientModelWithEmptySurname()
        {
            PacientModel pacientModel = new PacientModel
            {
                Name = "Juan",
                Surname = "",
                BirthDate = DateTime.Now,
                Cellphone = "097654123",
                Email = "juan@gmail.com"
            };
            PacientModelValidator validator = new PacientModelValidator();

            validator.Validate(pacientModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPacientModelWithEmptyCellphone()
        {
            PacientModel pacientModel = new PacientModel
            {
                Name = "Juan",
                Surname = "Gallicchio",
                BirthDate = DateTime.Now,
                Cellphone = "",
                Email = "juan@gmail.com"
            };
            PacientModelValidator validator = new PacientModelValidator();

            validator.Validate(pacientModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPacientModelWithEmptyEmail()
        {
            PacientModel pacientModel = new PacientModel
            {
                Name = "Juan",
                Surname = "Gallicchio",
                BirthDate = DateTime.Now,
                Cellphone = "097654123",
                Email = ""
            };
            PacientModelValidator validator = new PacientModelValidator();

            validator.Validate(pacientModel);
        }
    }
}
