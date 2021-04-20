using AutoMapper;
using Domain;
using Model.Out;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter.Mapper
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
