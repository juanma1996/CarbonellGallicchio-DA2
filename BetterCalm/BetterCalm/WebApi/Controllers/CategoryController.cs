using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterCalm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Category> categories = new List<Category>();
            Category category = new Category();
            categories.Add(category);
            return Ok(categories);
        }

        [HttpGet("{categoryId}/playlist", Name = "GetPlaylist")]
        public IActionResult GetPlaylistByCategory([FromRoute]int categoryId)
        {
            try
            {
                List<Playlist> objectToReturn;
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
