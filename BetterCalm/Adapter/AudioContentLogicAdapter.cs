using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;
using System.Collections.Generic;
using ValidatorInterface;

namespace Adapter
{
    public class AudioContentLogicAdapter : IAudioContentLogicAdapter
    {
        private readonly int audioContentTypeId = 1;
        private readonly IPlayableContentLogic playableContentLogic;
        private readonly IMapper mapper;
        private readonly IValidator<AudioContentModel> audioContentModelValidator;
        private readonly IValidator<PlaylistModel> playlistModelValidator;
        public AudioContentLogicAdapter(IPlayableContentLogic playableContentLogic, IModelMapper mapper,
            IValidator<AudioContentModel> audioContentModelValidator, IValidator<PlaylistModel> playlistModelValidator)
        {
            this.playableContentLogic = playableContentLogic;
            this.mapper = mapper.Configure();
            this.audioContentModelValidator = audioContentModelValidator;
            this.playlistModelValidator = playlistModelValidator;
        }

        public AudioContentBasicInfoModel GetById(int audioContentId)
        {
            try
            {
                PlayableContent audioContent = playableContentLogic.GetById(audioContentId);
                AudioContentBasicInfoModel audioContentBasicInfoModel = mapper.Map<AudioContentBasicInfoModel>(audioContent);
                return audioContentBasicInfoModel;
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
        public AudioContentBasicInfoModel Add(AudioContentModel audioContentModel)
        {
            audioContentModelValidator.Validate(audioContentModel);
            audioContentModel.Playlists.ForEach(p => playlistModelValidator.Validate(p));
            try
            {
                PlayableContent audioContentIn = mapper.Map<PlayableContent>(audioContentModel);
                audioContentIn.PlayableContentTypeId = audioContentTypeId;
                PlayableContent audioContent = playableContentLogic.Create(audioContentIn);
                AudioContentBasicInfoModel audioContentBasicInfoModel = mapper.Map<AudioContentBasicInfoModel>(audioContent);
                return audioContentBasicInfoModel;
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
        public void DeleteById(int audioContentId)
        {
            try
            {
                playableContentLogic.DeleteById(audioContentId);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
        public void Update(AudioContentModel audioContentModel)
        {
            try
            {
                audioContentModelValidator.Validate(audioContentModel);
                audioContentModel.Playlists.ForEach(p => playlistModelValidator.Validate(p));
                PlayableContent audioContentToUpdate = mapper.Map<PlayableContent>(audioContentModel);
                audioContentToUpdate.PlayableContentTypeId = audioContentTypeId;
                playableContentLogic.Update(audioContentToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }

        public List<AudioContentBasicInfoModel> GetByCategoryId(int categoryId)
        {
            List<PlayableContent> playableContents = playableContentLogic.GetByCategoryId(categoryId, audioContentTypeId);
            List<AudioContentBasicInfoModel> audioContentsBasicInfoModel =  mapper.Map<List<AudioContentBasicInfoModel>>(playableContents);
            return audioContentsBasicInfoModel;
        }

        public List<AudioContentBasicInfoModel> GetByPlaylistId(int playlistId)
        {
            List<PlayableContent> playableContents = playableContentLogic.GetByPlaylistId(playlistId, audioContentTypeId);
            List<AudioContentBasicInfoModel> audioContentsBasicInfoModel = mapper.Map<List<AudioContentBasicInfoModel>>(playableContents);
            return audioContentsBasicInfoModel;
        }

        public List<AudioContentBasicInfoModel> GetAll()
        {
            List<PlayableContent> playableContents = playableContentLogic.GetAll(audioContentTypeId);
            List<AudioContentBasicInfoModel> audioContentsBasicInfoModel = mapper.Map<List<AudioContentBasicInfoModel>>(playableContents);
            return audioContentsBasicInfoModel;
        }
    }
}