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
            PlayableContent audioContentToReturn = new PlayableContent()
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
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<PlayableContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.GetAll(It.IsAny<Expression<Func<Category, bool>>>())).Returns(new List<Category>());
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.GetAll(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(new List<Playlist>());
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

            PlayableContent result = audioContentLogic.GetById(audioContentId);

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
            PlayableContent audioContentModel = new PlayableContent()
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
            mock.Setup(m => m.Add(It.IsAny<PlayableContent>())).Returns(audioContentModel);
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<PlayableContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            mockCategoryPlaylist.Setup(m => m.Add(It.IsAny<CategoryPlaylist>())).Returns(It.IsAny<CategoryPlaylist>());
            mockCategoryPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<CategoryPlaylist, bool>>>())).Returns(false);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.Exists(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(true);
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

            PlayableContent result = audioContentLogic.Create(audioContentModel);

            mock.VerifyAll();
            Assert.AreEqual(audioContentId, result.Id);
        }

        [TestMethod]
        public void TestDeleteAudioContentOk()
        {
            int audioContentId = 1;
            PlayableContent audioContentToReturn = new PlayableContent
            {
                Id = audioContentId
            };
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(audioContentId)).Returns(audioContentToReturn);
            mock.Setup(m => m.Delete(It.IsAny<PlayableContent>()));
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<PlayableContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.GetAll(It.IsAny<Expression<Func<Category, bool>>>())).Returns(new List<Category>());
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.GetAll(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(new List<Playlist>());
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

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
            PlayableContent audioContentUpdated = new PlayableContent()
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
            mock.Setup(m => m.Update(It.IsAny<PlayableContent>()));
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<PlayableContent>()));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            mockCategoryPlaylist.Setup(m => m.Add(It.IsAny<CategoryPlaylist>())).Returns(It.IsAny<CategoryPlaylist>());
            mockCategoryPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<CategoryPlaylist, bool>>>())).Returns(false);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.Exists(It.IsAny<Expression<Func<Category, bool>>>())).Returns(true);
            mockPlaylist.Setup(m => m.Exists(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(true);
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            mockPlayableContentPlaylist.Setup(m => m.Add(It.IsAny<PlayableContentPlaylist>())).Returns(It.IsAny<PlayableContentPlaylist>());
            mockPlayableContentPlaylist.Setup(m => m.DeleteAll(It.IsAny<Expression<Func<PlayableContentPlaylist, bool>>>()));
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            mockPlayableContentCategory.Setup(m => m.DeleteAll(It.IsAny<Expression<Func<PlayableContentCategory, bool>>>()));
            mockPlayableContentCategory.Setup(m => m.Add(It.IsAny<PlayableContentCategory>())).Returns(It.IsAny<PlayableContentCategory>());
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

            audioContentLogic.Update(audioContentUpdated);

            mock.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NullObjectException))]
        public void TestDeleteAudioContentNotExistent()
        {
            int audioContentId = 1;
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(It.IsAny<int>())).Returns((PlayableContent)null);
            mock.Setup(m => m.Delete(It.IsAny<PlayableContent>()));
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<PlayableContent>())).Throws(new NullObjectException("Audio content not exist"));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mockCategory.Setup(m => m.GetAll(It.IsAny<Expression<Func<Category, bool>>>())).Returns(It.IsAny<List<Category>>());
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mockPlaylist.Setup(m => m.GetAll(It.IsAny<Expression<Func<Playlist, bool>>>())).Returns(It.IsAny<List<Playlist>>());
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

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
            PlayableContent audioContentUpdated = new PlayableContent()
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
            mock.Setup(m => m.Update(It.IsAny<PlayableContent>()));
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            validatorMock.Setup(m => m.Validate(It.IsAny<PlayableContent>())).Throws(new NullObjectException("Audio content not exist"));
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic audioContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

            audioContentLogic.Update(audioContentUpdated);

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
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PlayableContent, bool>>>())).Returns(audioContentsToReturn);
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic playableContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

            List<PlayableContent> audioContents = playableContentLogic.GetByCategoryId(categoryId, 1);

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
            };
            PlayableContent secondAudioContentToReturn = new PlayableContent()
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
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PlayableContent, bool>>>())).Returns(audioContentsToReturn);
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic playableContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

            List<PlayableContent> audioContents = playableContentLogic.GetByPlaylistId(playlistId, 1);

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
            Mock<IRepository<PlayableContent>> mock = new Mock<IRepository<PlayableContent>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PlayableContent, bool>>>())).Returns(audioContentsToReturn);
            Mock<IValidator<PlayableContent>> validatorMock = new Mock<IValidator<PlayableContent>>(MockBehavior.Strict);
            Mock<IRepository<CategoryPlaylist>> mockCategoryPlaylist = new Mock<IRepository<CategoryPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<Category>> mockCategory = new Mock<IRepository<Category>>(MockBehavior.Strict);
            Mock<IRepository<Playlist>> mockPlaylist = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentPlaylist>> mockPlayableContentPlaylist = new Mock<IRepository<PlayableContentPlaylist>>(MockBehavior.Strict);
            Mock<IRepository<PlayableContentCategory>> mockPlayableContentCategory = new Mock<IRepository<PlayableContentCategory>>(MockBehavior.Strict);
            PlayableContentLogic playableContentLogic = new PlayableContentLogic(mock.Object, validatorMock.Object,
                mockCategoryPlaylist.Object, mockCategory.Object, mockPlaylist.Object, mockPlayableContentPlaylist.Object, mockPlayableContentCategory.Object);

            List<PlayableContent> audioContents = playableContentLogic.GetAll(1);

            mock.VerifyAll();
            Assert.AreEqual(audioContentsToReturn.Count, audioContents.Count);
        }
    }
}
