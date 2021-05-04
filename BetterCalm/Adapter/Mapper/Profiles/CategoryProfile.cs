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
            CreateMap<AudioContentCategory, AudioContentBasicInfoModel>()
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.AudioContent.Name))
                .ForMember(p => p.AudioUrl, opt => opt.MapFrom(c => c.AudioContent.AudioUrl))
                .ForMember(p => p.CreatorName, opt => opt.MapFrom(c => c.AudioContent.CreatorName))
                .ForMember(p => p.Duration, opt => opt.MapFrom(c => c.AudioContent.Duration))
                .ForMember(p => p.ImageUrl, opt => opt.MapFrom(c => c.AudioContent.ImageUrl))
                .ForMember(p => p.Name, opt => opt.MapFrom(c => c.AudioContent.Name));
        }
    }
}
