﻿using BusinessExceptions;
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
                List<PlaylistBasicInfoModel> playlists = categoryLogic.GetPlaylistsBy(categoryId);
                return Ok(playlists);
            }
            catch (NullObjectException e)
            {
                return NotFound(e);
            }
        }
    }
}
