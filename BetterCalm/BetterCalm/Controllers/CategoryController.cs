using Microsoft.AspNetCore.Mvc;
using Model.Out;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterCalm.WebApi.Controllers
{
    public class CategoryController : BetterCalmControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<CategoryBasicInfoModel> categories = new List<CategoryBasicInfoModel>();
            CategoryBasicInfoModel category = new CategoryBasicInfoModel();
            categories.Add(category);
            return Ok(categories);
        }

        [HttpGet("{categoryId}/playlist", Name = "GetPlaylist")]
        public IActionResult GetPlaylistByCategory([FromRoute]int categoryId)
        {
            try
            {
                List<PlaylistBasicInfoModel> objectToReturn;
                List<Playlist> playlists = new List<Playlist>();
                Playlist playlist = new Playlist();
                playlists.Add(playlist);
                Category category = new Category()
                {
                    Id = 1,
                    Playlists = playlists
                };
                List<Category> categories = new List<Category>();
                categories.Add(category);

                Category foundCategory = categories.Where(c => c.Id.Equals(categoryId)).FirstOrDefault();
                if (foundCategory == null)
                {
                    throw new ArgumentException("Categoría inexistente");
                }
                else
                {
                    objectToReturn = foundCategory.Playlists;
                }

                return Ok(objectToReturn);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
