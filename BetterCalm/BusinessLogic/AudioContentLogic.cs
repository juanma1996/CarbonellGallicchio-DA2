﻿using BusinessLogicInterface;
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
        public AudioContent Create(AudioContent audioContentModel)
        {
            return audioContentRepository.Add(audioContentModel);
        }
        public void DeleteById(int audioContentId)
        {
            AudioContent audioContentToDelete = audioContentRepository.GetById(audioContentId);
            audioContentRepository.Delete(audioContentToDelete);
        }
        public void Update(AudioContent audioContentModel)
        {
            audioContentRepository.Update(audioContentModel);
        }
    }
}