using BusinessExceptions;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using ValidatorInterface;

namespace BusinessLogic
{
    public class AudioContentLogic : IAudioContentLogic
    {
        private IRepository<AudioContent> audioContentRepository;
        private IValidator<AudioContent> audioContentValidator;

        public AudioContentLogic(IRepository<AudioContent> audioContentRepository, IValidator<AudioContent> audioContentValidator)
        {
            this.audioContentRepository = audioContentRepository;
            this.audioContentValidator = audioContentValidator;
        }
        public AudioContent GetById(int audioContentId)
        {
            AudioContent audioContent = audioContentRepository.GetById(audioContentId);
            audioContentValidator.Validate(audioContent);
            return audioContent;

        }
        public AudioContent Create(AudioContent audioContentModel)
        {
            return audioContentRepository.Add(audioContentModel);
        }
        public void DeleteById(int audioContentId)
        {
            AudioContent audioContentToDelete = GetById(audioContentId);
            audioContentRepository.Delete(audioContentToDelete);
        }
        public void Update(AudioContent audioContentModel)
        {
            if (!audioContentRepository.Exists(a => a.Id == audioContentModel.Id))
            {
                throw new NullObjectException("Audio content not exist for the given data");
            }
            else
            {
                audioContentRepository.Update(audioContentModel);
            }
        }
    }
}