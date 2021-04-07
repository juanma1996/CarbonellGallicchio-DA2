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
            IEnumerable<Category> categories = categoryLogic.GetAll();
            IEnumerable <CategoryBasicInfoModel> categoriesOut = mapper.Map<IEnumerable<CategoryBasicInfoModel>>(categories);
            return Ok(categoriesOut);
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
