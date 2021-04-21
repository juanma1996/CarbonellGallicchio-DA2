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

        public AudioContentLogic(IRepository<AudioContent> audioContentRepository)
        {
            this.audioContentRepository = audioContentRepository;
        }

        public AudioContent GetById(int audioContentId)
        {
            return audioContentRepository.GetById(audioContentId);
        }

        public object Create(AudioContent audioContentModel)
        {
            throw new NotImplementedException();
        }
    }
}