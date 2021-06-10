using BusinessExceptions;
using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ValidatorInterface;

namespace BusinessLogicTests
{
    [TestClass]
    public class PlayableContentLogicTest
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
                Url = "www.audio.com"
            };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.GetAll(It.IsAny<Expression<Func<Category, bool>>>())).Returns(new List<Category>());
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.GetAll(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(new List<Playlist>());
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

            AudioContent result = (AudioContent)audioContentLogic.GetById(audioContentId);

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
                Url = "www.audio.com",
                Categories = new List<PlayableContentCategory>()
                {
                    new PlayableContentCategory()
                    {
                        CategoryId = categoryId
                    }
                },
                Playlists = new List<PlayableContentPlaylist>()
                {
                    new PlayableContentPlaylist()
                    {
                        PlaylistId = playlistId
                    }
                },
            };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.Add(It.IsAny<AudioContent>())).Returns(audioContentModel);
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            mockCategoryPlaylist.Setup(m => m.Add(It.IsAny<CategoryPlaylist>())).Returns(It.IsAny<CategoryPlaylist>());
            mockCategoryPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<CategoryPlaylist, bool>>>())).Returns(false);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.Exists(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(true);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

            AudioContent result = (AudioContent)audioContentLogic.Create(audioContentModel);

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
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            mock.Setup(m => m.Delete(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.GetAll(It.IsAny<Expression<Func<Category, bool>>>())).Returns(new List<Category>());
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.GetAll(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(new List<Playlist>());
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

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
                Url = "www.audio.com",
                Categories = new List<PlayableContentCategory>()
                {
                    new PlayableContentCategory()
                    {
                        CategoryId = categoryId
                    }
                },
                Playlists = new List<PlayableContentPlaylist>()
                {
                    new PlayableContentPlaylist()
                    {
                        PlaylistId = playlistId
                    }
                },
            };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == audioContentUpdated.Id)).Returns(true);
            mock.Setup(m => m.Update(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            mockCategoryPlaylist.Setup(m => m.Add(It.IsAny<CategoryPlaylist>())).Returns(It.IsAny<CategoryPlaylist>());
            mockCategoryPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<CategoryPlaylist, bool>>>())).Returns(false);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.Exists(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            mockPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(true);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

            audioContentLogic.Update(audioContentUpdated);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestDeleteAudioContentNotExistent()
        {
            int audioContentId = 1;
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Returns((AudioContent)null);
            mock.Setup(m => m.Delete(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>())).Throws(new NullObjectException("Audio content not exist"));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.GetAll(It.IsAny<Expression<Func<Category, bool>>>())).Returns(It.IsAny<List<Category>>());
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.GetAll(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(It.IsAny<List<Playlist>>());
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

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
                Url = "www.audio.com",
                Categories = new List<PlayableContentCategory>()
                {
                    new PlayableContentCategory()
                    {
                        CategoryId = categoryId
                    }
                },
                Playlists = new List<PlayableContentPlaylist>()
                {
                    new PlayableContentPlaylist()
                    {
                        PlaylistId = playlistId
                    }
                },
            };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.Exists(a => a.Id == audioContentUpdated.Id)).Returns(false);
            mock.Setup(m => m.Update(It.IsAny<AudioContent>()));
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<AudioContent>())).Throws(new NullObjectException("Audio content not exist"));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

            audioContentLogic.Update(audioContentUpdated);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetAudioContentsByCategoryOk()
        {
            int categoryId = 1;
            AudioContent firstAudioContentToReturn = new AudioContent()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
            };
            AudioContent secondAudioContentToReturn = new AudioContent()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com"
            };
            List<PlayableContent> audioContentsToReturn = new List<PlayableContent>() { firstAudioContentToReturn, secondAudioContentToReturn };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(p => p.Categories.Any(pCategory => pCategory.CategoryId == categoryId))).Returns(audioContentsToReturn);
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            PlayableContentLogic playableContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

            List<PlayableContent> audioContents = playableContentLogic.GetByCategoryId(categoryId);

            mock.VerifyAll();
            Assert.AreEqual(audioContentsToReturn.Count, audioContents.Count);
        }

        [TestMethod]
        public void TestGetAudioContentsByPlaylistOk()
        {
            int playlistId = 1;
            AudioContent firstAudioContentToReturn = new AudioContent()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
            };
            AudioContent secondAudioContentToReturn = new AudioContent()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com"
            };
            List<PlayableContent> audioContentsToReturn = new List<PlayableContent>() { firstAudioContentToReturn, secondAudioContentToReturn };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(p => p.Playlists.Any(pPlaylist => pPlaylist.PlaylistId == playlistId))).Returns(audioContentsToReturn);
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            PlayableContentLogic playableContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

            List<PlayableContent> audioContents = playableContentLogic.GetByPlaylistId(playlistId);

            mock.VerifyAll();
            Assert.AreEqual(audioContentsToReturn.Count, audioContents.Count);
        }

        [TestMethod]
        public void TestGetAudioContentsOk()
        {
            AudioContent firstAudioContentToReturn = new AudioContent()
            {
                Id = 1,
                Name = "One Song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com",
            };
            AudioContent secondAudioContentToReturn = new AudioContent()
            {
                Id = 2,
                Name = "Another song",
                Duration = TimeSpan.MaxValue,
                CreatorName = "Juan",
                ImageUrl = "www.unaimagen.com",
                Url = "www.audio.com"
            };
            List<PlayableContent> audioContentsToReturn = new List<PlayableContent>() { firstAudioContentToReturn, secondAudioContentToReturn };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(null)).Returns(audioContentsToReturn);
            Mock<IValidator<AudioContent>> validatorMock = new Mock<IValidator<AudioContent>>(MockBehavior.Strict);
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            PlayableContentLogic playableContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object);

            List<PlayableContent> audioContents = playableContentLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(audioContentsToReturn.Count, audioContents.Count);
        }
    }
}
