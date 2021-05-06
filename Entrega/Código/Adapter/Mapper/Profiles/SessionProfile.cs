using System;
using AutoMapper;
using Domain;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, SessionBasicInfoModel>()
                .ForMember(s => s.Token, x => x.MapFrom(z => z.Token))
                .ForMember(s => s.Email, x => x.MapFrom(z => z.Administrator.Email));
        }
    }
}
