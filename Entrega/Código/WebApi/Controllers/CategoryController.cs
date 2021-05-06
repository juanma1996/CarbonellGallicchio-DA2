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

        // GET: 
        /// <summary>
        /// Obtains all the categories.
        /// </summary>
        /// <remarks>
        /// Obtains all the information of the categories on the system.
        /// </remarks>
        /// <response code="200">Success. Returns the list of categories.</response>  
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet]
        public IActionResult Get()
        {
            List<CategoryBasicInfoModel> categories = categoryDomainToModelAdapter.GetAll();
            return Ok(categories);
        }

        // GET: 
        /// <summary>
        /// Obtains all the playlists related to a category.
        /// </summary>
        /// <remarks>
        /// Obtains all the playlist related to a category.
        /// </remarks>
        /// <response code="200">Success. Returns the list of playlists.</response>  
        /// <response code="404">NotFound. Playlist not exist for the given data.</response>
        /// <response code="500">InternalServerError. Server problems, unexpected error.</response>
        [HttpGet("{id}/playlists", Name = "GetPlaylist")]
        public IActionResult GetPlaylistByCategory([FromRoute] int id)
        {
            List<PlaylistBasicInfoModel> playlists = categoryDomainToModelAdapter.GetPlaylistsByCategoryId(id);
            return Ok(playlists);
        }
    }
}
