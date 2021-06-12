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
using System;
using System.Collections.Generic;
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
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new AudioContentProfile()));
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
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            audioContentLogicAdapter.GetById(audioContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteByIdAudioContentNotExistentId()
        {
            int audioContentId = 1;
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.DeleteById(It.IsAny<int>())).Throws(new NullObjectException("Not exist audio content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

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
            mock.Setup(m => m.Update(It.IsAny<PlayableContent>())).Throws(new NullObjectException("Not exist audio content"));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

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
                Name = "",
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
            mock.Setup(m => m.Create(It.IsAny<PlayableContent>())).Returns(It.IsAny<PlayableContent>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

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
                Name = "",
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
            mock.Setup(m => m.Update(It.IsAny<PlayableContent>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            audioContentLogicAdapter.Update(audioContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestCreateAudioContentWithInvalidPlaylist()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = audioContentId,
                Name = "Audio content",
                Playlists = new List<PlaylistModel>()
                {
                    new PlaylistModel()
                    {
                        Id = 1,
                        Name = "",
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
            mock.Setup(m => m.Create(It.IsAny<PlayableContent>())).Returns(It.IsAny<PlayableContent>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>())).Throws(new InvalidAttributeException("Playlist name can't be empty"));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            audioContentLogicAdapter.Add(audioContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateAudioContentWithInvalidPlaylist()
        {
            int audioContentId = 1;
            AudioContentModel audioContentModel = new AudioContentModel()
            {
                Id = audioContentId,
                Name = "Audio content",
                Playlists = new List<PlaylistModel>()
                {
                    new PlaylistModel()
                    {
                        Id = 1,
                        Name = "",
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
            mock.Setup(m => m.Update(It.IsAny<PlayableContent>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<AudioContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>())).Throws(new InvalidAttributeException("Playlist name can't be empty"));
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            audioContentLogicAdapter.Update(audioContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetAudioContentsByCategoryOk()
        {
            int categoryId = 1;
            PlayableContent firstAudioContentToReturn = new PlayableContent()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
            };
            PlayableContent secondAudioContentToReturn = new PlayableContent()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
                PlayableContentTypeId = 1
            };
            List<PlayableContent> audioContentsToReturn = new List<PlayableContent>() { firstAudioContentToReturn, secondAudioContentToReturn };
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetByCategoryId(categoryId, 1)).Returns(audioContentsToReturn);
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            List<AudioContentBasicInfoModel> audioContents = audioContentLogicAdapter.GetByCategoryId(categoryId);

            mock.VerifyAll();
            Assert.AreEqual(audioContentsToReturn.Count, audioContents.Count);
        }

        [TestMethod]
        public void TestGetAudioContentsByPlaylistOk()
        {
            int playlistId = 1;
            PlayableContent firstAudioContentToReturn = new PlayableContent()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
                PlayableContentTypeId = 1
            };
            PlayableContent secondAudioContentToReturn = new PlayableContent()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
                PlayableContentTypeId = 1
            };
            List<PlayableContent> audioContentsToReturn = new List<PlayableContent>() { firstAudioContentToReturn, secondAudioContentToReturn };
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetByPlaylistId(playlistId, 1)).Returns(audioContentsToReturn);
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            List<AudioContentBasicInfoModel> audioContents = audioContentLogicAdapter.GetByPlaylistId(playlistId);

            mock.VerifyAll();
            Assert.AreEqual(audioContentsToReturn.Count, audioContents.Count);
        }

        [TestMethod]
        public void TestGetAudioContentsOk()
        {
            PlayableContent firstAudioContentToReturn = new PlayableContent()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
                PlayableContentTypeId = 1
            };
            PlayableContent secondAudioContentToReturn = new PlayableContent()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
                PlayableContentTypeId = 1
            };
            List<PlayableContent> audioContentsToReturn = new List<PlayableContent>() { firstAudioContentToReturn, secondAudioContentToReturn };
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(1)).Returns(audioContentsToReturn);
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<AudioContentModel>> mockValidator = new Mock<IValidator<AudioContentModel>>(MockBehavior.Strict);
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            AudioContentLogicAdapter audioContentLogicAdapter = new AudioContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            List<AudioContentBasicInfoModel> audioContents = audioContentLogicAdapter.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(audioContentsToReturn.Count, audioContents.Count);
        }
    }
}
