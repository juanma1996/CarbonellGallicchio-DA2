using System;
using AutoMapper;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class AdministratorProfile : Profile
    {
        public AdministratorProfile()
        {
            CreateMap<AdministratorModel, Administrator>();
            CreateMap<Administrator, AdministratorBasicInfoModel>();
        }
    }
}
