using System;
using AutoMapper;
using Domain;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryBasicInfoModel>();
        }
    }
}
