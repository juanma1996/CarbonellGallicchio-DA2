using Adapter;
using Adapter.Mapper;
using Adapter.Mapper.Profiles;
using AutoMapper;
using BusinessLogicInterface;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Out;
using Moq;
using System.Collections.Generic;

namespace AdapterTests
{
    [TestClass]
    public class PlaylistLogicAdapterTest
    {
        [TestMethod]
        public void TestPlaylistMapOk()
        {
            ModelMapper mapper = new ModelMapper();
            MapperConfiguration configuration = new MapperConfiguration(mapper => mapper.AddProfile(new PlaylistProfile()));
            configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void TestGetPlaylistsOk()
        {
            Playlist firstPlaylistToReturn = new Playlist()
            {
                Id = 1,
                Name = "One playlist",
            };
            Playlist secondPlaylistToReturn = new Playlist()
            {
                Id = 2,
                Name = "Another playlist"
            };
            List<Playlist> playlistsToReturn = new List<Playlist>() { firstPlaylistToReturn, secondPlaylistToReturn };
            Mock<IPlaylistLogic> mock = new Mock<IPlaylistLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(playlistsToReturn);
            ModelMapper mapper = new ModelMapper();
            PlaylistLogicAdapter playlistLogicAdapter = new PlaylistLogicAdapter(mock.Object, mapper);

            List<PlaylistBasicInfoModel> playlists = playlistLogicAdapter.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(playlistsToReturn.Count, playlists.Count);
        }
    }
}
