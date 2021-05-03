using Adapter.Mapper;
using AdapterInterface;
using AutoMapper;
using BusinessLogicInterface;
using Domain;
using Model.In;
using Model.Out;
using System;

namespace Adapter
{
    public class AudioContentLogicAdapter : IAudioContentLogicAdapter
    {
        private readonly IAudioContentLogic audioContentLogic;
        private readonly IMapper mapper;
        public AudioContentLogicAdapter(IAudioContentLogic audioContentLogic, IModelMapper mapper)
        {
            this.audioContentLogic = audioContentLogic;
            this.mapper = mapper.Configure();
        }

        public AudioContentBasicInfoModel GetById(int audioContentId)
        {
            AudioContent audioContent = audioContentLogic.GetById(audioContentId);
            return mapper.Map<AudioContentBasicInfoModel>(audioContent);
        }
        public AudioContentBasicInfoModel Add(AudioContentModel audioContentModel)
        {
            AudioContent audioContentIn = mapper.Map<AudioContent>(audioContentModel);
            AudioContent audioContent = audioContentLogic.Create(audioContentIn);
            return mapper.Map<AudioContentBasicInfoModel>(audioContent);
        }
        public void DeleteById(int audioContentId)
        {
            audioContentLogic.DeleteById(audioContentId);
        }
        public void Update(AudioContentModel audioContentModel)
        {
            AudioContent audioContentToUpdate = mapper.Map<AudioContent>(audioContentModel);
        }
    }
}