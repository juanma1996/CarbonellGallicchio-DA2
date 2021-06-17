using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebApi.Controllers;

namespace WebApiTests
{
    [TestClass]
    public class PlaylistControllerTest
    {
        [TestMethod]
        public void TestGetAllPlaylistOk()
        {
            List<PlaylistBasicInfoModel> playlistToReturn = new List<PlaylistBasicInfoModel>()
            {
                new PlaylistBasicInfoModel
                {
                    Id = 1,
                    Name = "Top 50 Uruguay"
                },
                new PlaylistBasicInfoModel
                {
                    Id = 2,
                    Name = "Top 50 Usa"
                }
            };
            Mock<IPlaylistLogicAdapter> mock = new Mock<IPlaylistLogicAdapter>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(playlistToReturn);
            PlaylistController controller = new PlaylistController(mock.Object);

            var result = controller.Get();
            OkObjectResult okResult = result as OkObjectResult;
            List<PlaylistBasicInfoModel> playlists = okResult.Value as List<PlaylistBasicInfoModel>;

            mock.VerifyAll();
            Assert.AreEqual(playlists.First().Id, playlistToReturn.First().Id);
            Assert.AreEqual(playlists.First().Name, playlistToReturn.First().Name);
            Assert.AreEqual(playlists.Count, playlistToReturn.Count);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
