using AutoMapper;
using ImporterLogic.Mapper.Profiles;

namespace ImporterLogic.Mapper
{
    public class ModelMapper : IModelMapper
    {
        public IMapper Configure()
        {
            MapperConfiguration config = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<PlayableContentProfile>();
            });

            return config.CreateMapper();
        }
    }
}
