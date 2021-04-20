using AdapterExceptions;
using AdapterInterface;
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
        private readonly ICategoryLogicAdapter categoryDomainToModelAdapter;

        public CategoryController(ICategoryLogicAdapter categoryDomainToModelAdapter)
        {
            this.categoryDomainToModelAdapter = categoryDomainToModelAdapter;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<CategoryBasicInfoModel> categories = categoryDomainToModelAdapter.GetAll();
            return Ok(categories);
        }

        [HttpGet("{categoryId}/playlist", Name = "GetPlaylist")]
        public IActionResult GetPlaylistByCategory([FromRoute] int categoryId)
        {
            try
            {
                List<PlaylistBasicInfoModel> playlists = categoryDomainToModelAdapter.GetPlaylistsByCategoryId(categoryId);
                return Ok(playlists);
            }
            catch (NullObjectMappingException e)
            {
                return NotFound(e);
            }
        }
    }
}
