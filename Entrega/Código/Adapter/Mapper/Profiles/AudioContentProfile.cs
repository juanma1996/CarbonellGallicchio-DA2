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
                
            CreateMap<CategoryModel, AudioContentCategory>()
                .ForMember(c => c.AudioContent , opt => opt.Ignore())
                .ForMember(c => c.AudioContentId, opt => opt.Ignore())
                .ForMember(c => c.Category, opt => opt.Ignore())
                .ForMember(c => c.CategoryId, opt => opt.MapFrom(x => x.Id));
            CreateMap<PlaylistModel, AudioContentPlaylist>()
                .ForMember(c => c.Playlist, opt => opt.Condition(x => x.Id == default))
                .ForMember(c => c.Playlist, opt => opt.MapFrom(x => x))
                .ForMember(c => c.AudioContentId, opt => opt.Ignore())
                .ForMember(c => c.AudioContent, opt => opt.Ignore())
                .ForMember(c => c.PlaylistId, opt => opt.MapFrom(x => x.Id));
            CreateMap<PlaylistModel, Playlist>()
                .ForMember(c => c.Categories, opt => opt.Ignore())
                .ForMember(c => c.AudioContents, opt => opt.Ignore());
        }
    }
}
