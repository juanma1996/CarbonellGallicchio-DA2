using BusinessExceptions;
using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ValidatorInterface;

namespace BusinessLogicTests
{
    [TestClass]
    public class AudioContentLogicTest
    {
        [TestMethod]
        public void TestGetAudioContentOk()
        {
            int audioContentId = 1;
            AudioContent audioContentToReturn = new AudioContent()
            {
                Id = audioContentId,
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com"
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object);

            AudioContent result = audioContentLogic.GetById(audioContentId);

            mock.VerifyAll();
            Assert.AreEqual(audioContentToReturn.Id, result.Id);
            Assert.AreEqual(audioContentToReturn.Name, result.Name);
        }

        [TestMethod]
        public void TestCreateAudioContentOk()
        {
            int audioContentId = 1;
            int categoryId = 1;
            int playlistId = 1;
            AudioContent audioContentModel = new AudioContent()
            {
                Id = audioContentId,
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
                Categories = new List<AudioContentCategory>()
                {
                    new AudioContentCategory()
                    {
                        CategoryId = categoryId
                    }
                },
                Playlists = new List<AudioContentPlaylist>()
                {
                    new AudioContentPlaylist()
                    {
                        PlaylistId = playlistId
                    }
                },
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContent>())).Returns(audioContentModel);
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            mockCategoryPlaylist.Setup(m => m.Add(It.IsAny<CategoryPlaylist>())).Returns(It.IsAny<CategoryPlaylist>());
            mockCategoryPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<CategoryPlaylist, bool>>>())).Returns(false);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object);

            AudioContent result = audioContentLogic.Create(audioContentModel);

            mock.VerifyAll();
            Assert.AreEqual(audioContentId, result.Id);
        }

        [TestMethod]
        public void TestDeleteAudioContentOk()
        {
            int audioContentId = 1;
            AudioContent audioContentToReturn = new AudioContent
            {
                Id = audioContentId
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            mock.Setup(m => m.Delete(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object);

            audioContentLogic.DeleteById(audioContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestUpdateAudioContentOk()
        {
            int audioContentId = 1;
            int categoryId = 1;
            int playlistId = 1;
            Category newCategory = new Category
            {
                Id = categoryId
            };
            Playlist newPlaylist = new Playlist
            {
                Id = playlistId
            };
            AudioContent audioContentUpdated = new AudioContent()
            {
                Id = audioContentId,
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
                Categories = new List<AudioContentCategory>()
                {
                    new AudioContentCategory()
                    {
                        CategoryId = categoryId
                    }
                },
                Playlists = new List<AudioContentPlaylist>()
                {
                    new AudioContentPlaylist()
                    {
                        PlaylistId = playlistId
                    }
                },
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == audioContentUpdated.Id)).Returns(true);
            mock.Setup(m => m.Update(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            mockCategoryPlaylist.Setup(m => m.Add(It.IsAny<CategoryPlaylist>())).Returns(It.IsAny<CategoryPlaylist>());
            mockCategoryPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<CategoryPlaylist, bool>>>())).Returns(false);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object);

            audioContentLogic.Update(audioContentUpdated);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestDeleteAudioContentNotExistent()
        {
            int audioContentId = 1;
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Returns((AudioContent)null);
            mock.Setup(m => m.Delete(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>())).Throws(new NullObjectException("Audio content not exist"));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object);

            audioContentLogic.DeleteById(audioContentId);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestUpdateAudioContentNotExistent()
        {
            int audioContentId = 1;
            int categoryId = 1;
            int playlistId = 1;
            Category newCategory = new Category
            {
                Id = categoryId
            };
            Playlist newPlaylist = new Playlist
            {
                Id = playlistId
            };
            AudioContent audioContentUpdated = new AudioContent()
            {
                Id = audioContentId,
                Name = "Canción",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                AudioUrl = "www.audio.com",
                Categories = new List<AudioContentCategory>()
                {
                    new AudioContentCategory()
                    {
                        CategoryId = categoryId
                    }
                },
                Playlists = new List<AudioContentPlaylist>()
                {
                    new AudioContentPlaylist()
                    {
                        PlaylistId = playlistId
                    }
                },
            };
            Mock<IRepository<AudioContent>> mock = new Mock<IRepository<AudioContent>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == audioContentUpdated.Id)).Returns(false);
            mock.Setup(m => m.Update(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>())).Throws(new NullObjectException("Audio content not exist"));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            AudioContentLogic audioContentLogic = new AudioContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object);

            audioContentLogic.Update(audioContentUpdated);

            mock.VerifyAll();
        }
    }
}
