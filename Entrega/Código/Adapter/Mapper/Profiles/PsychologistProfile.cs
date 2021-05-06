using System;
using AutoMapper;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class PsychologistProfile : Profile
    {
        public PsychologistProfile()
        {
            CreateMap<Psychologist, PsychologistBasicInfoModel>();
            CreateMap<PsychologistProblematic, ProblematicBasicInfoModel>()
                .ForMember(p => p.Name, opt => opt.MapFrom(c => c.Problematic.Name))
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.Problematic.Id));

            CreateMap<PsychologistModel, Psychologist>();
            CreateMap<ProblematicModel, PsychologistProblematic>()
                .ForMember(p => p.ProblematicId, opt => opt.MapFrom(c => c.Id))
                .ForMember(p => p.PsychologistId, opt => opt.Ignore())
                .ForMember(p => p.Psychologist, opt => opt.Ignore())
                .ForMember(p => p.Problematic, opt => opt.Ignore());
        }
    }
}
