using AutoMapper;
using Domain;
using Model.Out;

namespace BusinessLogic.Mapper
{
    public class ModelMapper : IModelMapper
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