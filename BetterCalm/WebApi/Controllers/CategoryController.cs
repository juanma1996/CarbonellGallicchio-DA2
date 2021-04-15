using AutoMapper;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Model.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Mapper;

namespace BetterCalm.WebApi.Controllers
{
    public class CategoryController : BetterCalmControllerBase
    {
        private readonly ICategoryLogic categoryLogic;
        private readonly IMapper mapper;

        public CategoryController(ICategoryLogic categoryLogic,IApiMapper mapper)
        {
            this.categoryLogic = categoryLogic;
            this.mapper = mapper.Configure();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories = categoryLogic.GetAll();
            List<CategoryBasicInfoModel> categoriesOut = mapper.Map<List<CategoryBasicInfoModel>>(categories);
            return Ok(categoriesOut);
        }

        [HttpGet("{categoryId}/playlist", Name = "GetPlaylist")]
        public IActionResult GetPlaylistByCategory([FromRoute] int categoryId)
        {
            try
            {
                List<Playlist> playlists = categoryLogic.GetPlaylistsBy(categoryId);
                List<PlaylistBasicInfoModel> playlistsOut = mapper.Map<List<PlaylistBasicInfoModel>>(playlists);
                return Ok(playlistsOut);
            }
            catch (NullReferenceException e)
            {
                return NotFound(e);
            }
        }
    }
}
