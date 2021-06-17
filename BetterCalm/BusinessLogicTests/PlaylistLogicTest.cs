using BusinessLogic;
using DataAccessInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BusinessLogicTests
{
    [TestClass]
    public class PlaylistLogicTest
    {
        [TestMethod]
        public void TestGetAllPlaylists()
        {
            List<Playlist> playlistToReturn = new List<Playlist>()
            {
                new Playlist
                {
                    Id = 1
                }
            };
            Mock<IRepository<Playlist>> mock = new Mock<IRepository<Playlist>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll(null)).Returns(playlistToReturn);
            PlaylistLogic playlistLogic = new PlaylistLogic(mock.Object);

            List<Playlist> result = playlistLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(playlistToReturn.Count, result.Count);
        }
    }
}
