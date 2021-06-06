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
        public void TestUpdateVideoContentNotExistent()
        {
            int videoContentId = 1;
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Id = videoContentId,
                Name = "One video content",
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

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestCreateVideoContentNotValidName()
        {
            int videoContentId = 1;
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Id = videoContentId,
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
            mock.Setup(m => m.Create(It.IsAny<VideoContent>())).Returns(It.IsAny<VideoContent>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            videoContentLogicAdapter.Add(videoContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateVideoContentNotValidName()
        {
            int videoContentId = 1;
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Id = videoContentId,
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
            mock.Setup(m => m.Update(It.IsAny<VideoContent>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>())).Throws(new InvalidAttributeException("Name can't be empty"));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>()));
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            videoContentLogicAdapter.Update(videoContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestCreateVideoContentWithInvalidPlaylist()
        {
            int videoContentId = 1;
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Id = videoContentId,
                Name = "Video content",
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
            mock.Setup(m => m.Create(It.IsAny<VideoContent>())).Returns(It.IsAny<VideoContent>());
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>())).Throws(new InvalidAttributeException("Playlist name can't be empty"));
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            videoContentLogicAdapter.Add(videoContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAttributeException))]
        public void TestUpdateVideoContentWithInvalidPlaylist()
        {
            int videoContentId = 1;
            VideoContentModel videoContentModel = new VideoContentModel()
            {
                Id = videoContentId,
                Name = "Video content",
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
            mock.Setup(m => m.Update(It.IsAny<VideoContent>()));
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            mockPlaylistModelValidator.Setup(m => m.Validate(It.IsAny<PlaylistModel>())).Throws(new InvalidAttributeException("Playlist name can't be empty"));
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            videoContentLogicAdapter.Update(videoContentModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetVideoContentsByCategoryOk()
        {
            int categoryId = 1;
            VideoContent firstVideoContentToReturn = new VideoContent()
            {
                Id = 1,
                Name = "One video",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "",
                Url = "www.video.com",
            };
            VideoContent secondVideoContentToReturn = new VideoContent()
            {
                Id = 2,
                Name = "Another video",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "",
                Url = "www.video.com"
            };
            List<PlayableContent> videoContentsToReturn = new List<PlayableContent>() { firstVideoContentToReturn, secondVideoContentToReturn };
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetByCategoryId(categoryId)).Returns(videoContentsToReturn);
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            List<VideoContentBasicInfoModel> videoContents = videoContentLogicAdapter.GetByCategoryId(categoryId);

            mock.VerifyAll();
            Assert.AreEqual(videoContentsToReturn.Count, videoContents.Count);
        }

        [TestMethod]
        public void TestGetVideoContentsByPlaylistOk()
        {
            int playlistId = 1;
            VideoContent firstVideoContentToReturn = new VideoContent()
            {
                Id = 1,
                Name = "One video",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "",
                Url = "www.video.com",
            };
            VideoContent secondVideoContentToReturn = new VideoContent()
            {
                Id = 2,
                Name = "Another video",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "",
                Url = "www.video.com"
            };
            List<PlayableContent> videoContentsToReturn = new List<PlayableContent>() { firstVideoContentToReturn, secondVideoContentToReturn };
            Mock<IPlayableContentLogic> mock = new Mock<IPlayableContentLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetByPlaylistId(playlistId)).Returns(videoContentsToReturn);
            ModelMapper mapper = new ModelMapper();
            Mock<IValidator<VideoContentModel>> mockValidator = new Mock<IValidator<VideoContentModel>>(MockBehavior.Strict);
            mockValidator.Setup(m => m.Validate(It.IsAny<VideoContentModel>()));
            Mock<IValidator<PlaylistModel>> mockPlaylistModelValidator = new Mock<IValidator<PlaylistModel>>(MockBehavior.Strict);
            VideoContentLogicAdapter videoContentLogicAdapter = new VideoContentLogicAdapter(mock.Object, mapper,
                mockValidator.Object, mockPlaylistModelValidator.Object);

            List<VideoContentBasicInfoModel> videoContents = videoContentLogicAdapter.GetByPlaylistId(playlistId);

            mock.VerifyAll();
            Assert.AreEqual(videoContentsToReturn.Count, videoContents.Count);
        }
    }
}
