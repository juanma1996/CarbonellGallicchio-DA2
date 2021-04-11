using AutoMapper;
using Domain;
using Model.Out;

namespace WebApi.Mapper
{
    public class ApiMapper : IApiMapper
    {
        public IMapper Configure()
        {
            var config = new MapperConfiguration(mapper =>
            {
                mapper.CreateMap<Category, CategoryBasicInfoModel>();
                mapper.CreateMap<Playlist, PlaylistBasicInfoModel>();
            });

            return config.CreateMapper();
        }
    }
}