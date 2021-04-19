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
        private readonly Validation validate;

        public CategoryLogic(IRepository<Category> categoryRepository, IModelMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper.Configure();
            this.validate = new Validation();
        }

        public List<CategoryBasicInfoModel> GetAll()
        {
            List<CategoryBasicInfoModel> categories = mapper.Map<List<CategoryBasicInfoModel>>(categoryRepository.GetAll());
            return categories;
        }

        public List<PlaylistBasicInfoModel> GetPlaylistsBy(int categoryId)
        {
            Category category = categoryRepository.GetById(categoryId);
            validate.Validate(category);
            List<Playlist> playlists = category.Playlists;
            validate.Validate(playlists);
            List<PlaylistBasicInfoModel> playlistsModel = mapper.Map<List<PlaylistBasicInfoModel>>(playlists);
            return playlistsModel;
        }
    }
}