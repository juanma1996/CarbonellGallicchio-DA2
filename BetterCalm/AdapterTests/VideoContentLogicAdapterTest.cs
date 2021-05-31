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
using Moq;
using System.Collections.Generic;
using ValidatorInterface;

namespace AdapterTests
{
    [TestClass]
    public class VideoContentLogicAdapterTest
    {
        [TestMethod]
        public void TestVideoContentMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new VideoContentProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestGetByIdVideoContentNotExistentId()
        {
            int videoContentId = 1;
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new NullObjectException("Not exist video content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            videoContentLogicAdapter.GetById(videoContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteByIdVideoContentNotExistentId()
        {
            int videoContentId = 1;
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(It.IsAny<int>())).Throws(new NullObjectException("Not exist video content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            videoContentLogicAdapter.DeleteById(videoContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestUpdateAudioContentNotExistent()
        {
            int audioContentId = 1;
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Id = audioContentId,
                Name = "One audio content",
                Playlists = new List<PlaylistModel>()
                {
                    new PlaylistModel()
                    {
                        Id = 1,
                        Name = "Name",
                        Description = "Description"
                    }
                },
                Categories = new List<CategoryModel>()
                {
                    new CategoryModel()
                    {
                        Id = 1,
                        Name = "Name"
                    }
                }
            };
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.Update(It.IsAny<VideoContent>())).Throws(new NullObjectException("Not exist video content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            videoContentLogicAdapter.Update(videoContentModel);

            mock.VerifyAll();
        }
    }
}
