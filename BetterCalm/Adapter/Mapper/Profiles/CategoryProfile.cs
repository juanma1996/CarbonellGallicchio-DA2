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
            CreateMap<PlayableContentCategory, AudioContentBasicInfoModel>()
                .ForMember(p => p.Id, opt => opt.MapFrom(c => c.PlayableContent.Name))
                .ForMember(p => p.AudioUrl, opt => opt.Ignore())
                .ForMember(p => p.CreatorName, opt => opt.MapFrom(c => c.PlayableContent.CreatorName))
                .ForMember(p => p.Duration, opt => opt.MapFrom(c => c.PlayableContent.Duration))
                .ForMember(p => p.ImageUrl, opt => opt.Ignore())
                .ForMember(p => p.Name, opt => opt.MapFrom(c => c.PlayableContent.Name));
        }
    }
}
