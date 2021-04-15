using BusinessLogicInterface;
using Domain;
using System;
using System.Collections.Generic;
using DataAccessInterface;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = categoryRepository.GetAll();
            return categories;
        }

        public List<Playlist> GetPlaylistsBy(int categoryId)
        {
            List<Playlist> playlist = categoryRepository.GetPlaylistsBy(categoryId);
            ValidateNullPlaylist(playlist);
            return playlist;
        }

        private void ValidateNullPlaylist(List<Playlist> playlists)
        {
            if (playlists == null)
            {
                throw new NullReferenceException("Doesn't exists playlist for this category");
            }
        }

    }
}