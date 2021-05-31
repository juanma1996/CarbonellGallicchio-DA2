using AutoMapper;
using Domain;
using Model.In;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class VideoContentProfile : Profile
    {
        public VideoContentProfile()
        {
            CreateMap<VideoContent, VideoContentBasicInfoModel>();

            CreateMap<VideoContentModel, VideoContent>();

            CreateMap<CategoryModel, PlayableContentCategory>()
                .ForMember(c => c.PlayableContent, opt => opt.Ignore())
                .ForMember(c => c.PlayableContentId, opt => opt.Ignore())
                .ForMember(c => c.Category, opt => opt.Ignore())
                .ForMember(c => c.CategoryId, opt => opt.MapFrom(x => x.Id));
            CreateMap<PlaylistModel, PlayableContentPlaylist>()
                .ForMember(c => c.Playlist, opt => opt.Condition(x => x.Id == default))
                .ForMember(c => c.Playlist, opt => opt.MapFrom(x => x))
                .ForMember(c => c.PlayableContentId, opt => opt.Ignore())
                .ForMember(c => c.PlayableContent, opt => opt.Ignore())
                .ForMember(c => c.PlaylistId, opt => opt.MapFrom(x => x.Id));
            CreateMap<PlaylistModel, Playlist>()
                .ForMember(c => c.Categories, opt => opt.Ignore())
                .ForMember(c => c.AudioContents, opt => opt.Ignore());
        }
    }
}
