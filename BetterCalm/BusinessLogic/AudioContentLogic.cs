using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class AudioContentLogic : IAudioContentLogic
    {
        private IRepository<AudioContent> audioContentRepository;
        private readonly Validation validation = new Validation();

        public AudioContentLogic(IRepository<AudioContent> audioContentRepository)
        {
            this.audioContentRepository = audioContentRepository;
        }
        public AudioContent GetById(int audioContentId)
        {
            AudioContent audioContent = audioContentRepository.GetById(audioContentId);
            validation.Validate(audioContent);
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
            audioContentRepository.Update(audioContentModel);
        }
    }
}