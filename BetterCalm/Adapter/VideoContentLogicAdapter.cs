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
            throw new NotImplementedException();
        }
        public void DeleteById(int videoContentId)
        {
            throw new NotImplementedException();
        }
        public void Update(VideoContentModel videoContentModel)
        {
            throw new NotImplementedException();
        }
    }
}
