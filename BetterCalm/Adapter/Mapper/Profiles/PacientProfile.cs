using System;
using AutoMapper;
using Domain;
using Model.In;

namespace Adapter.Mapper.Profiles
{
    public class PacientProfile : Profile
    {
        public PacientProfile()
        {
            CreateMap<PacientModel, Pacient>().ForMember(prop => prop.Id, opt => opt.Ignore());
        }
    }
}
