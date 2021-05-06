using Adapter.Mapper;
using AdapterExceptions;
using AdapterInterface;
using AutoMapper;
using BusinessExceptions;
using BusinessLogicInterface;
using Model.Out;
using System.Collections.Generic;

namespace Adapter
{
    public class CategoryLogicAdapter : ICategoryLogicAdapter
    {
        private readonly ICategoryLogic categoryLogic;
        private readonly IMapper mapper;

        public CategoryLogicAdapter(ICategoryLogic categoryLogic, IModelMapper mapper)
        {
            this.categoryLogic = categoryLogic;
            this.mapper = mapper.Configure();
        }

        public List<CategoryBasicInfoModel> GetAll()
        {
            return mapper.Map<List<CategoryBasicInfoModel>>(categoryLogic.GetAll());
        }
        public List<PlaylistBasicInfoModel> GetPlaylistsByCategoryId(int categoryId)
        {
            try
            {
                return mapper.Map<List<PlaylistBasicInfoModel>>(categoryLogic.GetPlaylistsByCategoryId(categoryId));
            }
            catch (NullObjectException ex)
            {
                throw new NotFoundException(ex.errorMessage);
            }
        }
    }
}
