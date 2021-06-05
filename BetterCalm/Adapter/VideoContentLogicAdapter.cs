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
using ValidatorInterface;

namespace Adapter
{
    public class VideoContentLogicAdapter : IVideoContentLogicAdapter
    {
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
                VideoContent videoContent = (VideoContent)playableContentLogic.GetById(videoContentId);
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
                VideoContent videoContentIn = mapper.Map<VideoContent>(videoContentModel);
                VideoContent videoContent = (VideoContent)playableContentLogic.Create(videoContentIn);
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
        public void Update(VideoContentModel videoContentModel)
        {
            try
            {
                videoContentModelValidator.Validate(videoContentModel);
                videoContentModel.Playlists.ForEach(p => playlistModelValidator.Validate(p));
                VideoContent videoContentToUpdate = mapper.Map<VideoContent>(videoContentModel);
                playableContentLogic.Update(videoContentToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
    }
}
