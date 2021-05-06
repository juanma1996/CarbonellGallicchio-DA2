using AdapterInterface;
using Microsoft.AspNetCore.Mvc;
using Model.Out;
using System.Collections.Generic;

namespace BetterCalm.WebApi.Controllers
{
    [Route("api/categories")]
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

        [HttpGet("{id}/playlists", Name = "GetPlaylist")]
        public IActionResult GetPlaylistByCategory([FromRoute] int id)
        {
            List<PlaylistBasicInfoModel> playlists = categoryDomainToModelAdapter.GetPlaylistsByCategoryId(id);
            return Ok(playlists);
        }
    }
}
