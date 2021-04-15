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
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryLogic(ICategoryRepository categoryRepository, IModelMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper.Configure();
        }

        public List<CategoryBasicInfoModel> GetAll()
        {
            List<CategoryBasicInfoModel> categories = mapper.Map<List<CategoryBasicInfoModel>>(categoryRepository.GetAll());
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