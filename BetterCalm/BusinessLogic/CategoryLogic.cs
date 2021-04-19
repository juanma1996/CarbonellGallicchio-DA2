using BusinessLogicInterface;
using Domain;
using System;
using Model.Out;
using System.Collections.Generic;
using DataAccessInterface;
using AutoMapper;
using BusinessLogic.Mapper;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CategoryLogic(IRepository<Category> categoryRepository, IModelMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper.Configure();
        }

        public List<CategoryBasicInfoModel> GetAll()
        {
            List<CategoryBasicInfoModel> categories = mapper.Map<List<CategoryBasicInfoModel>>(categoryRepository.GetAll());
            return categories;
        }

        public List<PlaylistBasicInfoModel> GetPlaylistsBy(int categoryId)
        {
            Category category = categoryRepository.GetById(categoryId);
            ValidateNullCategory(category);
            List<Playlist> playlists = category.Playlists;
            ValidateNullPlaylist(playlists);
            List<PlaylistBasicInfoModel> playlistsModel = mapper.Map<List<PlaylistBasicInfoModel>>(playlists);
            return playlistsModel;
        }

        private void ValidateNullCategory(Category category)
        {
            if (category == null)
            {
                throw new NullReferenceException("Doesn't exists category for this id");
            }
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