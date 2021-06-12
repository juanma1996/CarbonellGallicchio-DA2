using AdapterInterface;
using BetterCalm.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Model.Out;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/playlists")]
    public class PlaylistController : BetterCalmControllerBase
    {
        private readonly IPlaylistLogicAdapter playlistLogicAdapter;

        public PlaylistController(IPlaylistLogicAdapter playlistLogicAdapter)
        {
            this.playlistLogicAdapter = playlistLogicAdapter;
        }

        // GET: 
        /// <summary>
        /// Obtains all the playlists.
        /// </summary>
        /// <remarks>
        /// Obtains all the information of the playlists on the system.
        /// </remarks>
        /// <response code="200">Success. Returns the list of playlists.</response>  
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet]
        public IActionResult Get()
        {
            List<PlaylistBasicInfoModel> playlists = playlistLogicAdapter.GetAll();
            return Ok(playlists);
        }
    }
}
