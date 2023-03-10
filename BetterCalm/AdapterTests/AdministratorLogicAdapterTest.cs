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
            AdministratorModel administrator = new AdministratorModel()
            {
                Id = 1,
                Email = "oneMailgmail.com",
                Name = "Juan",
                Password = "pass"
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Administrator>())).Throws(new NullObjectException("Not exist Administrator"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>()));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administrator);

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
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "",
                Email = "Juan@gmail.com",
                Password = "Password01",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Administrator>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidPassword()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "Juan@gmail.com",
                Password = "",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Administrator>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administratorModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAdministratorInvalidEmail()
        {
            AdministratorModel administratorModel = new AdministratorModel
            {
                Name = "Juan",
                Email = "",
                Password = "Password01",
            };
            Mock<IAdministratorLogic> mock = new Mock<IAdministratorLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<Administrator>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AdministratorModel>> mockAdministratorModel = new Mock<IValidator<AdministratorModel>>(MockBehavior.Strict);
            mockAdministratorModel.Setup(m => m.Validate(It.IsAny<AdministratorModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AdministratorLogicAdapter administratorLogicAdapter = new AdministratorLogicAdapter(mock.Object, mapper, mockAdministratorModel.Object);

            administratorLogicAdapter.Update(administratorModel);

            mock.VerifyAll();
        }
    }
}
