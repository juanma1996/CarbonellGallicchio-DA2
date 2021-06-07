using AdapterExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using System.Collections.Generic;
using Validator;

namespace ValidatorTests
{
    [TestClass]
    public class PsychologistModelValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPsychologistModelWithEmptyName()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1,
                    Name = "Juan"
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "",
                ConsultationMode = "Virtual",
                Direction = "Some description",
                Problematics = problematics
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPsychologistModelWithEmptyConsultationMode()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1,
                    Name = "Juan"
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "",
                Direction = "Some direction",
                Problematics = problematics
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPsychologistModelWithEmptyDirection()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1,
                    Name = "Juan"
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "Presencial",
                Direction = "",
                Problematics = problematics
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        [ExpectedException(typeof(AmountOfProblematicsException))]
        public void TestPsychologistModelWithZeroProblematics()
        {
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "Presencial",
                Direction = "One direction",
                Problematics = new List<ProblematicModel>()
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        public void TestPsychologistModelIsCorrectVirtualType()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1,
                    Name = "Juan"
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "Virtual",
                Direction = "Direction",
                Problematics = problematics
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        public void TestPsychologistModelIsCorrectPresenceType()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1,
                    Name = "Juan"
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "Presencial",
                Direction = "Direction",
                Problematics = problematics
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPsychologistModelIncorrectConsultationMode()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1,
                    Name = "Juan"
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "Not virtual either presence type consultation mode",
                Direction = "Direction",
                Problematics = problematics
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }        

        [TestMethod]
        [ExpectedException(typeof(AmountOfProblematicsException))]
        public void TestPsychologistModelWithMoreThanThreeProblematics()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                },
                new ProblematicModel()
                {
                    Id = 4
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "Virtual",
                Direction = "Direction",
                Problematics = problematics
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPsychologistModelWithInvalidFee()
        {
            List<ProblematicModel> problematics = new List<ProblematicModel>()
            {
                new ProblematicModel()
                {
                    Id = 1,
                    Name = "Juan"
                },
                new ProblematicModel()
                {
                    Id = 2
                },
                new ProblematicModel()
                {
                    Id = 3
                }
            };
            PsychologistModel psychologist = new PsychologistModel
            {
                Name = "Juan",
                ConsultationMode = "Virtual",
                Direction = "Some description",
                Problematics = problematics,
                Fee = 0
            };
            PsychologistModelValidator validator = new PsychologistModelValidator();

            validator.Validate(psychologist);
        }
    }
}
