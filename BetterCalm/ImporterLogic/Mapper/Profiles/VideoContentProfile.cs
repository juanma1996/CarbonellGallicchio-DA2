using AutoMapper;
using ImporterInterface.Models;
using Model.In;

namespace ImporterLogic.Mapper.Profiles
{
    public class VideoContentProfile : Profile
    {
        public VideoContentProfile()
        {
            CreateMap<ContentImporterModel, VideoContentModel>()
                .ForMember(c => c.VideoUrl, opt => opt.MapFrom(x => x.Url));

            CreateMap<CategoryImporterModel, CategoryModel>();
            CreateMap<PlaylistImporterModel, PlaylistModel>();
        }
    }
}
