using System;
using AutoMapper;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class AudioContentProfile : Profile
    {
        public AudioContentProfile()
        {
            CreateMap<AudioContent, AudioContentBasicInfoModel>();

            CreateMap<AudioContentModel, AudioContent>();
            CreateMap<CategoryBasicInfoModel, AudioContentCategory>()
                .ForMember(c => c.AudioContent , opt => opt.Ignore())
                .ForMember(c => c.AudioContentId, opt => opt.Ignore())
                .ForMember(c => c.Category, opt => opt.Ignore())
                .ForMember(c => c.CategoryId, opt => opt.MapFrom(x => x.Id));
            CreateMap<PlaylistBasicInfoModel, AudioContentPlaylist>()
                .ForMember(c => c.Playlist, opt => opt.Ignore())
                .ForMember(c => c.AudioContentId, opt => opt.Ignore())
                .ForMember(c => c.AudioContent, opt => opt.Ignore())
                .ForMember(c => c.PlaylistId, opt => opt.MapFrom(x => x.Id));
        }
    }
}
