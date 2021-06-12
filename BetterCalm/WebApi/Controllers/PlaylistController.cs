using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using System;

namespace WebApi.Controllers
{
    public class PlaylistController : BetterCalmControllerBase
    {
        private readonly IPlaylistLogicAdapter playlistLogicAdapter;

        public PlaylistController(IPlaylistLogicAdapter playlistLogicAdapter)
        {
            this.playlistLogicAdapter = playlistLogicAdapter;
        }

        public object Get()
        {
            throw new NotImplementedException();
        }
    }
}
