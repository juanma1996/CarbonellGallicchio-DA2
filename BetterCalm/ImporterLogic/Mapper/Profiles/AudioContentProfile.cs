using AutoMapper;
using ImporterInterface.Models;
using Model.In;

namespace ImporterLogic.Mapper.Profiles
{
    public class AudioContentProfile : Profile
    {
        public AudioContentProfile()
        {
            CreateMap<ContentImporterModel, AudioContentModel>()
                .ForMember(c => c.AudioUrl, opt => opt.MapFrom(x => x.Url));

            CreateMap<CategoryImporterModel, CategoryModel>();
            CreateMap<PlaylistImporterModel, PlaylistModel>();
        }
    }
}
