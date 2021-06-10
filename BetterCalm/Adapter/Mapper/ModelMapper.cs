using Adapter.Mapper.Profiles;
using AutoMapper;
using Domain;
using Model.Out;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Mapper
{
    public class ModelMapper : IModelMapper
    {
        public IMapper Configure()
        {
            MapperConfiguration config = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<CategoryProfile>();
                mapper.AddProfile<PlaylistProfile>();
                mapper.AddProfile<PacientProfile>();
                mapper.AddProfile<AdministratorProfile>();
                mapper.AddProfile<ProblematicProfile>();
                mapper.AddProfile<ConsultationProfile>();
                mapper.AddProfile<PsychologistProfile>();
                mapper.AddProfile<AudioContentProfile>();
                mapper.AddProfile<SessionProfile>();
                mapper.AddProfile<VideoContentProfile>();
                mapper.AddProfile<BonusProfile>();
            });

            return config.CreateMapper();
        }
    }
}
