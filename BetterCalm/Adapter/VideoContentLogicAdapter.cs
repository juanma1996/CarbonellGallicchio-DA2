using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;
using System;
using System.Collections.Generic;
using ValidatorInterface;

namespace Adapter
{
    public class VideoContentLogicAdapter : IVideoContentLogicAdapter
    {
        private readonly int videoContentTypeId = 2;
        private readonly IPlayableContentLogic playableContentLogic;
        private readonly IMapper mapper;
        private readonly IValidator<VideoContentModel> videoContentModelValidator;
        private readonly IValidator<PlaylistModel> playlistModelValidator;
        public VideoContentLogicAdapter(IPlayableContentLogic playableContentLogic, IModelMapper mapper,
            IValidator<VideoContentModel> videoContentModelValidator, IValidator<PlaylistModel> playlistModelValidator)
        {
            this.playableContentLogic = playableContentLogic;
            this.mapper = mapper.Configure();
            this.videoContentModelValidator = videoContentModelValidator;
            this.playlistModelValidator = playlistModelValidator;
        }

        public VideoContentBasicInfoModel GetById(int videoContentId)
        {
            try
            {
                PlayableContent videoContent = playableContentLogic.GetById(videoContentId);
                return mapper.Map<VideoContentBasicInfoModel>(videoContent);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
        public VideoContentBasicInfoModel Add(VideoContentModel videoContentModel)
        {
            videoContentModelValidator.Validate(videoContentModel);
            videoContentModel.Playlists.ForEach(p => playlistModelValidator.Validate(p));
            try
            {
                PlayableContent videoContentIn = mapper.Map<PlayableContent>(videoContentModel);
                videoContentIn.PlayableContentTypeId = videoContentTypeId;
                PlayableContent videoContent = playableContentLogic.Create(videoContentIn);
                return mapper.Map<VideoContentBasicInfoModel>(videoContent);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
        public void DeleteById(int videoContentId)
        {
            try
            {
                playableContentLogic.DeleteById(videoContentId);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
        public void Update(int id, VideoContentModel videoContentModel)
        {
            try
            {
                videoContentModelValidator.Validate(videoContentModel);
                videoContentModel.Playlists.ForEach(p => playlistModelValidator.Validate(p));
                PlayableContent videoContentToUpdate = mapper.Map<PlayableContent>(videoContentModel);
                videoContentToUpdate.PlayableContentTypeId = videoContentTypeId;
                playableContentLogic.Update(id, videoContentToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }

        public List<VideoContentBasicInfoModel> GetByCategoryId(int categoryId)
        {
            List<PlayableContent> playableContents = playableContentLogic.GetByCategoryId(categoryId, videoContentTypeId);
            List<VideoContentBasicInfoModel> videoContentsBasicInfoModel = mapper.Map<List<VideoContentBasicInfoModel>>(playableContents);
            return videoContentsBasicInfoModel;
        }

        public List<VideoContentBasicInfoModel> GetByPlaylistId(int playlistId)
        {
            List<PlayableContent> playableContents = playableContentLogic.GetByPlaylistId(playlistId, videoContentTypeId);
            List<VideoContentBasicInfoModel> videoContentsBasicInfoModel = mapper.Map<List<VideoContentBasicInfoModel>>(playableContents);
            return videoContentsBasicInfoModel;
        }

        public List<VideoContentBasicInfoModel> GetAll()
        {
            List<PlayableContent> playableContents = playableContentLogic.GetAll(videoContentTypeId);
            List<VideoContentBasicInfoModel> videoContentsBasicInfoModel = mapper.Map<List<VideoContentBasicInfoModel>>(playableContents);
            return videoContentsBasicInfoModel;
        }
    }
}
