using AutoMapper;
using Domain;
using ImporterInterface.Models;

namespace ImporterLogic.Mapper.Profiles
{
    public class PlayableContentProfile : Profile
    {
        public PlayableContentProfile()
        {
            CreateMap<ContentImporterModel, PlayableContent>();

            CreateMap<ContentCategoryModel, PlayableContentCategory>();
            CreateMap<ContentPlaylistModel, PlayableContentPlaylist>();
            CreateMap<CategoryImporterModel, Category>();
            CreateMap<PlaylistImporterModel, Playlist>();
        }
    }
}
