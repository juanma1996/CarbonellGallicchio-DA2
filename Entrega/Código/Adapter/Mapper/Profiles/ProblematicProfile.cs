using System;
using AutoMapper;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class ProblematicProfile : Profile
    {
        public ProblematicProfile()
        {
            CreateMap<Problematic, ProblematicBasicInfoModel>();
            CreateMap<ProblematicModel, Problematic>().ForMember(prop => prop.Psychologists, opt => opt.Ignore());
        }
    }
}
