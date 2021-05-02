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
            var config = new MapperConfiguration(mapper =>
            {
                mapper.CreateMap<Category, CategoryBasicInfoModel>();
                mapper.CreateMap<Playlist, PlaylistBasicInfoModel>();
                mapper.AddProfile<PacientProfile>();
                mapper.AddProfile<AdministratorProfile>();
                mapper.AddProfile<ProblematicProfile>();
                mapper.AddProfile<ConsultationProfile>();
                mapper.AddProfile<PsychologistProfile>();
            });

            return config.CreateMapper();
        }
    }
}
