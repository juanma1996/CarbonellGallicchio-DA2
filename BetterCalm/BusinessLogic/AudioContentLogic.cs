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
        private IRepository<AudioContent> @object;

        public AudioContentLogic(IRepository<AudioContent> @object)
        {
            this.@object = @object;
        }

        public AudioContent GetById(int audioContentId)
        {
            throw new NotImplementedException();
        }
    }
}
