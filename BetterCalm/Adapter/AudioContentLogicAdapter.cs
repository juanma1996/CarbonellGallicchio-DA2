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
                AudioContent audioContentIn = mapper.Map<AudioContent>(audioContentModel);
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
                AudioContent audioContentToUpdate = mapper.Map<AudioContent>(audioContentModel);
                playableContentLogic.Update(audioContentToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }

        public List<AudioContentBasicInfoModel> GetByCategoryId(int categoryId)
        {
            List<PlayableContent> playableContents = playableContentLogic.GetByCategoryId(categoryId);
            List<AudioContent> audioContents = new List<AudioContent>();
            foreach (var item in playableContents)
            {
                if (item is AudioContent audioContent)
                {
                    audioContents.Add(audioContent);
                }
            }
            List<AudioContentBasicInfoModel> audioContentsBasicInfoModel =  mapper.Map<List<AudioContentBasicInfoModel>>(audioContents);
            return audioContentsBasicInfoModel;
        }

        public List<AudioContentBasicInfoModel> GetByPlaylistId(int playlistId)
        {
            List<PlayableContent> playableContents = playableContentLogic.GetByPlaylistId(playlistId);
            List<AudioContent> audioContents = new List<AudioContent>();
            foreach (var item in playableContents)
            {
                if (item is AudioContent audioContent)
                {
                    audioContents.Add(audioContent);
                }
            }
            List<AudioContentBasicInfoModel> audioContentsBasicInfoModel = mapper.Map<List<AudioContentBasicInfoModel>>(audioContents);
            return audioContentsBasicInfoModel;
        }

        public List<AudioContentBasicInfoModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}