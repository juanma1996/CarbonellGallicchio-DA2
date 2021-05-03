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
            try
            {
                AudioContent audioContent = audioContentLogic.GetById(audioContentId);
                return mapper.Map<AudioContentBasicInfoModel>(audioContent);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.Message);
            }
        }
        public AudioContentBasicInfoModel Add(AudioContentModel audioContentModel)
        {
            AudioContent audioContentIn = mapper.Map<AudioContent>(audioContentModel);
            AudioContent audioContent = audioContentLogic.Create(audioContentIn);
            return mapper.Map<AudioContentBasicInfoModel>(audioContent);
        }
        public void DeleteById(int audioContentId)
        {
            try
            {
                audioContentLogic.DeleteById(audioContentId);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.Message);
            }
        }
        public void Update(AudioContentModel audioContentModel)
        {
            try
            {
                AudioContent audioContentToUpdate = mapper.Map<AudioContent>(audioContentModel);
                audioContentLogic.Update(audioContentToUpdate);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.Message);
            }
        }
    }
}