using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AdapterExceptions;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Moq;
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
        public void TestGetByIdAudioContentNotExistentId()
        {
            int audioContentId = 1;
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Throws(new NullObjectException("Not exist audio content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            VideoContentLogicAdapter audioContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            audioContentLogicAdapter.GetById(audioContentId);

            mock.VerifyAll();
        }
    }
}
