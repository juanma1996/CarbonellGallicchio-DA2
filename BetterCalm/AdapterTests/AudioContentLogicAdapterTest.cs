﻿using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AdapterExceptions;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Moq;
using ValidatorInterface;

namespace AdapterTests
{
    [TestClass]
    public class AudioContentLogicAdapterTest
    {
        [TestMethod]
        public void TestAudioContentMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            var configuration = new MapperConfiguration(mapper => mapper.AddProfile(new AudioContentProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetByIdAudioContentNotExistentId()
        {
            int audioContentId = 1;
            Mock<IAudioContentLogic> mock = new Mock<IAudioContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new NullObjectException("Not exist audio content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper, mockValidator.Object);

            audioContentLogicAdapter.GetById(audioContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteByIdAudioContentNotExistentId()
        {
            int audioContentId = 1;
            Mock<IAudioContentLogic> mock = new Mock<IAudioContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(It.IsAny<int>())).Throws(new NullObjectException("Not exist audio content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper, mockValidator.Object);

            audioContentLogicAdapter.DeleteById(audioContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestUpdateAudioContentNotExistent()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = audioContentId,
                Name = "One audio content"
            };
            Mock<IAudioContentLogic> mock = new Mock<IAudioContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<AudioContent>())).Throws(new NullObjectException("Not exist audio content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper, mockValidator.Object);

            audioContentLogicAdapter.Update(audioContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestCreateAudioContentNotValidName()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = audioContentId,
                Name = ""
            };
            Mock<IAudioContentLogic> mock = new Mock<IAudioContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Create(It.IsAny<AudioContent>())).Returns(It.IsAny<AudioContent>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper, mockValidator.Object);

            audioContentLogicAdapter.Add(audioContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAudioContentNotValidName()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = audioContentId,
                Name = ""
            };
            Mock<IAudioContentLogic> mock = new Mock<IAudioContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<AudioContent>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper, mockValidator.Object);

            audioContentLogicAdapter.Update(audioContentModel);

            mock.VerifyAll();
        }
    }
}
