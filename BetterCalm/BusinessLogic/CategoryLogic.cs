using BusinessLogicInterface;
using Domain;
using System.Collections.Generic;
using DataAccessInterface;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly Validation validate;

        public CategoryLogic(IRepository<Category> categoryRepository, Validation validate)
        {
            this.categoryRepository = categoryRepository;
            this.validate = validate;
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public List<Playlist> GetPlaylistsByCategoryId(int categoryId)
        {
            Category category = categoryRepository.GetById(categoryId);
            validate.Validate(category);
            List<Playlist> playlists = category.Playlists;
            validate.Validate(playlists);
            return playlists;
        }
    }
}