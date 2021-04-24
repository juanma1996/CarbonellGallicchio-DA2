using BusinessLogicInterface;
using Domain;
using System.Collections.Generic;
using DataAccessInterface;
using System.Linq;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Playlist> playlistRepository;
        private readonly Validation validate;

        public CategoryLogic(IRepository<Category> categoryRepository, IRepository<Playlist> playlistRepository, Validation validate)
        {
            this.categoryRepository = categoryRepository;
            this.playlistRepository = playlistRepository;
            this.validate = validate;
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public List<Playlist> GetPlaylistsByCategoryId(int categoryId)
        {

            var playlists = playlistRepository.GetAll(playlist => playlist.Categories.Any(playlistCategory => playlistCategory.CategoryId == categoryId));
            validate.Validate(playlists);
            return playlists;
        }
    }
}