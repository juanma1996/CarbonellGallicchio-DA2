using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.Out;
using System;
using System.Collections.Generic;

namespace BetterCalm.WebApi.Controllers
{
    public class CategoryController : BetterCalmControllerBase
    {
        private readonly ICategoryLogic categoryLogic;

        public CategoryController(ICategoryLogic categoryLogic)
        {
            this.categoryLogic = categoryLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<CategoryBasicInfoModel> categories = categoryLogic.GetAll();
            return Ok(categories);
        }

        [HttpGet("{categoryId}/playlist", Name = "GetPlaylist")]
        public IActionResult GetPlaylistByCategory([FromRoute] int categoryId)
        {
            try
            {
                List<Playlist> playlists = categoryLogic.GetPlaylistsBy(categoryId);
                //List<PlaylistBasicInfoModel> playlistsOut = mapper.Map<List<PlaylistBasicInfoModel>>(playlists);
                List<PlaylistBasicInfoModel> playlistsOut = null;
                return Ok(playlistsOut);
            }
            catch (NullReferenceException e)
            {
                return NotFound(e);
            }
        }
    }
}
