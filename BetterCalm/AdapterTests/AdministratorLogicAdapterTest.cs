using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AdapterExceptions;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Model.Out;
using Moq;
using System.Collections.Generic;
using ValidatorInterface;

namespace AdapterTests
{
    [TestClass]
    public class AdministratorLogicAdapterTest
    {
        [TestMethod]
        public void TestAdministratorMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new AdministratorProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetAdministratorNotExistentId()
        {
            int administratorId = 1;
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(administratorId)).Throws(new NullObjectException("Not exist Administrator"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>()));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            AdministratorBasicInfoModel result = administratorLogicAdapter.GetById(administratorId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(EntityAlreadyExistException))]
        public void TestAddAlreadyExistentAdministrator()
        {
            AdministratorModel administrator = new AdministratorModel()
            {
                Id = 1,
                Email = "oneMailgmail.com",
                Name = "Juan",
                Password = "pass"
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Administrator>())).Throws(new AlreadyExistException("Administrator already exists"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>()));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Add(administrator);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteAdministratorNotExistentId()
        {
            int administratorId = 1;
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(administratorId)).Throws(new NullObjectException("Not exist Administrator"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>()));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Delete(administratorId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestUpdateAdministratorNotExistentId()
        {
            int administratorId = 1;
            AdministratorModel administrator = new AdministratorModel()
            {
                Id = 1,
                Email = "oneMailgmail.com",
                Name = "Juan",
                Password = "pass"
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(administratorId, It.IsAny<Administrator>())).Throws(new NullObjectException("Not exist Administrator"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>()));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administratorId, administrator);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAdministratorInvalidName()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Administrator>())).Returns(It.IsAny<Administrator>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Add(administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAdministratorInvalidPassword()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Administrator>())).Returns(It.IsAny<Administrator>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Add(administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestPostAdministratorInvalidEmail()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "",
                Password = "Password01",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<Administrator>())).Returns(It.IsAny<Administrator>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Add(administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidName()
        {
            int administratorId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(administratorId, It.IsAny<Administrator>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administratorId, administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidPassword()
        {
            int administratorId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(administratorId, It.IsAny<Administrator>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administratorId, administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidEmail()
        {
            int administratorId = 1;
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "",
                Password = "Password01",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(administratorId, It.IsAny<Administrator>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administratorId, administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetAdministratorsOk()
        {
            Administrator firstAdministratorToReturn = new Administrator
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Administrator secondAdministratorToReturn = new Administrator
            {
                Name = "Fede",
                Email = "fede@gmail.com",
                Password = "Password01",
            };
            List<Administrator> administratorsToReturn = new List<Administrator>() { firstAdministratorToReturn, secondAdministratorToReturn };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(administratorsToReturn);
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            List<AdministratorBasicInfoModel> administrators = administratorLogicAdapter.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(administratorsToReturn.Count, administrators.Count);
        }
    }
}
