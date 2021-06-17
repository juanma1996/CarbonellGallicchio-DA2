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
            CreateMap<PlayableContent, AudioContentBasicInfoModel>()
                 .ForMember(c => c.AudioUrl, opt => opt.MapFrom(x => x.Url));

            CreateMap<PlayableContentPlaylist, PlaylistBasicInfoModel>()
               .ForMember(c => c.Description, opt => opt.MapFrom(x => x.Playlist.Description))
               .ForMember(c => c.Id, opt => opt.MapFrom(x => x.Playlist.Id))
               .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Playlist.Name));

            CreateMap<PlayableContentCategory, CategoryBasicInfoModel>()
               .ForMember(c => c.Id, opt => opt.MapFrom(x => x.Category.Id))
               .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Category.Name));

            CreateMap<AudioContentModel, PlayableContent>()
                .ForMember(c => c.PlayableContentTypeId, opt => opt.Ignore())
                .ForMember(c => c.PlayableContentType, opt => opt.Ignore())
                .ForMember(c => c.Url, opt => opt.MapFrom(x => x.AudioUrl));

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
                .ForMember(c => c.PlayableContents, opt => opt.Ignore());
        }
    }
}
