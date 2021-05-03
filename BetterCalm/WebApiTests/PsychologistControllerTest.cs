﻿using System;
using System.Collections.Generic;
using System.Linq;
using AdapterExceptions;
using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class PsychologistControllerTest
    {
        [TestMethod]
        public void TestGetPsychologistByIdOk()
        {
            var psychologistId = 1;
            PsychologistBasicInfoModel psychologistToReturn = new PsychologistBasicInfoModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<ProblematicBasicInfoModel>
                {
                    new ProblematicBasicInfoModel
                    {
                        Name = "Depresion"
                    },
                    new ProblematicBasicInfoModel
                    {
                        Name = "Ansiedad"
                    },
                    new ProblematicBasicInfoModel
                    {
                        Name = "Estres"
                    },
                    new ProblematicBasicInfoModel
                    {
                        Name = "Otros"
                    },
                }
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Returns(psychologistToReturn);
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.GetById(psychologistId);
            var okResult = result as OkObjectResult;
            var psychologist = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistToReturn.Id, psychologist.Id);
            Assert.AreEqual(psychologistToReturn.Name, psychologist.Name);
            Assert.AreEqual(psychologistToReturn.Direction, psychologist.Direction);
            Assert.AreEqual(psychologistToReturn.ConsultationMode, psychologist.ConsultationMode);
            Assert.AreEqual(psychologistToReturn.CreationDate, psychologist.CreationDate);
            Assert.AreEqual(psychologistToReturn.Problematics.First().Name, psychologist.Problematics.First().Name);
            Assert.AreEqual(psychologistToReturn.Problematics.Count, psychologist.Problematics.Count);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectMappingException))]
        public void TestGetPsychologistNotExistentId()
        {
            var psychologistId = 1;
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(psychologistId)).Throws(new NullObjectMappingException("prueba"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.GetById(psychologistId);
        }

        [TestMethod]
        public void TestPostPsychologistOk()
        {
            int psychologistId = 1;
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<ProblematicModel>
                {
                    new ProblematicModel
                    {
                        Name = "Depresion"
                    },
                    new ProblematicModel
                    {
                        Name = "Ansiedad"
                    },
                    new ProblematicModel
                    {
                        Name = "Estres"
                    },
                    new ProblematicModel
                    {
                        Name = "Otros"
                    },
                }
            };
            PsychologistBasicInfoModel psychologistToReturn = new PsychologistBasicInfoModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<ProblematicBasicInfoModel>
                {
                    new ProblematicBasicInfoModel
                    {
                        Name = "Depresion"
                    },
                    new ProblematicBasicInfoModel
                    {
                        Name = "Ansiedad"
                    },
                    new ProblematicBasicInfoModel
                    {
                        Name = "Estres"
                    },
                    new ProblematicBasicInfoModel
                    {
                        Name = "Otros"
                    },
                },
            };

            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<PsychologistModel>())).Returns(psychologistToReturn);
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Post(psycologistModel);
            var okResult = result as CreatedAtRouteResult;
            var psychologistBasicInfoModel = okResult.Value as PsychologistBasicInfoModel;

            mock.VerifyAll();
            Assert.AreEqual(psychologistId, psychologistBasicInfoModel.Id);
            Assert.AreEqual(psycologistModel.Problematics.Count, psychologistBasicInfoModel.Problematics.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostPsychologistInvalidName()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<PsychologistModel>())).Throws(new InvalidAttributeException("Invalid name"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Post(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostPsychologistInvalidDirection()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "Fede",
                Direction = "",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<PsychologistModel>())).Throws(new InvalidAttributeException("Invalid direction"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Post(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostPsychologistInvalidConsultationMode()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<PsychologistModel>())).Throws(new InvalidAttributeException("Invalid consultation mode"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Post(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(AmountOfProblematicsException))]
        public void TestPostPsychologistNoProblematics()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<PsychologistModel>())).Throws(new AmountOfProblematicsException());
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Post(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(AmountOfProblematicsException))]
        public void TestPostPsychologistExcessOfProblematics()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<ProblematicModel>
                {
                    new ProblematicModel
                    {
                        Name = "Depresion"
                    },
                    new ProblematicModel
                    {
                        Name = "Ansiedad"
                    },
                    new ProblematicModel
                    {
                        Name = "Estres"
                    },
                    new ProblematicModel
                    {
                        Name = "Enojo"
                    },
                    new ProblematicModel
                    {
                        Name = "Otros"
                    },
                }
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<PsychologistModel>())).Throws(new AmountOfProblematicsException());
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Post(psycologistModel);
        }

        [TestMethod]
        public void TestDeletePsychologistOk()
        {
            int psychologistId = 1;
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(psychologistId));
            PsychologistController controller = new PsychologistController(mock.Object);

            var response = controller.DeleteById(psychologistId);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectMappingException))]
        public void TestDeletePsychologistNotFound()
        {
            int psychologistId = 1;
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Delete(psychologistId)).Throws(new NullObjectMappingException());
            PsychologistController controller = new PsychologistController(mock.Object);

            var response = controller.DeleteById(psychologistId);
        }

        [TestMethod]
        public void TestUpdatePsychologistOk()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
                Problematics = new List<ProblematicModel>
                {
                    new ProblematicModel
                    {
                        Name = "Depresion"
                    },
                    new ProblematicModel
                    {
                        Name = "Ansiedad"
                    },
                    new ProblematicModel
                    {
                        Name = "Estres"
                    },
                    new ProblematicModel
                    {
                        Name = "Enojo"
                    },
                    new ProblematicModel
                    {
                        Name = "Otros"
                    },
                }
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<PsychologistModel>()));
            PsychologistController controller = new PsychologistController(mock.Object);

            var response = controller.Update(psycologistModel);
            var statusCodeResult = response as StatusCodeResult;

            mock.VerifyAll();
            Assert.AreEqual(204, statusCodeResult.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectMappingException))]
        public void TestUpdatePsychologistNotFound()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<PsychologistModel>())).Throws(new NullObjectMappingException("Unexistant psychologist"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var response = controller.Update(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdatePsychologistInvalidName()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Id = 1,
                Name = "",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<PsychologistModel>())).Throws(new InvalidAttributeException("Invalid name"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Update(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdatePsychologistInvalidDirection()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<PsychologistModel>())).Throws(new InvalidAttributeException("Invalid direction"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Update(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdatePsychologistInvalidConsultationMode()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio Negro",
                ConsultationMode = "",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<PsychologistModel>())).Throws(new InvalidAttributeException("Invalid conultation mode"));
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Update(psycologistModel);
        }

        [TestMethod]
        [ExpectedException(typeof(AmountOfProblematicsException))]
        public void TestUpdatePsychologistNoProblematics()
        {
            PsychologistModel psycologistModel = new PsychologistModel
            {
                Id = 1,
                Name = "Juan",
                Direction = "Rio negro",
                ConsultationMode = "Presencial",
                CreationDate = new DateTime(2021, 4, 20),
            };
            Mock<IPsychologistLogicAdapter> mock = new Mock<IPsychologistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<PsychologistModel>())).Throws(new AmountOfProblematicsException());
            PsychologistController controller = new PsychologistController(mock.Object);

            var result = controller.Update(psycologistModel);
        }
    }
}
