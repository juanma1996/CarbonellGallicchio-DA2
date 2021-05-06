using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;
using ValidatorInterface;

namespace Adapter
{
    public class AudioContentLogicAdapter : IAudioContentLogicAdapter
    {
        private readonly IAudioContentLogic audioContentLogic;
        private readonly IMapper mapper;
        private readonly IValidator<AudioContentModel> audioContentModelValidator;
        private readonly IValidator<PlaylistModel> playlistModelValidator;
        public AudioContentLogicAdapter(IAudioContentLogic audioContentLogic, IModelMapper mapper,
            IValidator<AudioContentModel> audioContentModelValidator, IValidator<PlaylistModel> playlistModelValidator)
        {
            this.audioContentLogic = audioContentLogic;
            this.mapper = mapper.Configure();
            this.audioContentModelValidator = audioContentModelValidator;
            this.playlistModelValidator = playlistModelValidator;
        }

        public AudioContentBasicInfoModel GetById(int audioContentId)
        {
            try
            {
                AudioContent audioContent = audioContentLogic.GetById(audioContentId);
                return mapper.Map<AudioContentBasicInfoModel>(audioContent);
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
                AudioContent audioContent = audioContentLogic.Create(audioContentIn);
                return mapper.Map<AudioContentBasicInfoModel>(audioContent);
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
                audioContentLogic.DeleteById(audioContentId);
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
                audioContentLogic.Update(audioContentToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
    }
}