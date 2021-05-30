using AutoMapper;
using Domain;
using Model.Out;

namespace Adapter.Mapper.Profiles
{
    public class VideoContentProfile : Profile
    {
        public VideoContentProfile()
        {
            CreateMap<VideoContent, VideoContentBasicInfoModel>();
        }
    }
}
