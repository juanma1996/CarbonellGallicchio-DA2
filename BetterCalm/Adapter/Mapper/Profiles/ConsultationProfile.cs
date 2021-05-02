using System;
using AutoMapper;
using Domain;
using Model.In;

namespace Adapter.Mapper.Profiles
{
    public class ConsultationProfile : Profile
    {
        public ConsultationProfile()
        {
            CreateMap<ConsultationModel, Consultation>()
                .ForMember(prop => prop.Id, opt => opt.Ignore())
                .ForMember(prop => prop.Psychologist, opt => opt.Ignore());
            CreateMap<PacientModel, Pacient>().ForMember(prop => prop.Id, opt => opt.Ignore());
        }
    }
}
