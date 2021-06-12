using BusinessLogicInterface;
using Domain;
using System.Collections.Generic;
using DataAccessInterface;
using System.Linq;
using ValidatorInterface;
using BusinessExceptions;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Playlist> playlistRepository;
        private readonly IValidator<Playlist> playlistValidator;

        public CategoryLogic(IRepository<Category> categoryRepository, IRepository<Playlist> playlistRepository,
            IValidator<Playlist> playlistValidator)
        {
            this.categoryRepository = categoryRepository;
            this.playlistRepository = playlistRepository;
            this.playlistValidator = playlistValidator;
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }
        public List<Playlist> GetPlaylistsByCategoryId(int categoryId)
        {
            List<Playlist> playlists = playlistRepository.GetAll(playlist => playlist.Categories.Any(playlistCategory => playlistCategory.CategoryId == categoryId));
            if (playlists != null && playlists.Count > 0)
            {
                playlistValidator.Validate(playlists.First());
            }
            else
            {
                throw new NullObjectException("Playlist not exist for the given data");
            }
            return playlists;
        }
    }
}