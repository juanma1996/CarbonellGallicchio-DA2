using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface ICategoryLogicAdapter
    {
        List<CategoryBasicInfoModel> GetAll();
        List<PlaylistBasicInfoModel> GetPlaylistsByCategoryId(int categoryId);
    }
}