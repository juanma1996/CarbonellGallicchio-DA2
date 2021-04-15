using System.Collections.Generic;
using Domain;
using Model.Out;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {
        List<CategoryBasicInfoModel> GetAll();
        List<Playlist> GetPlaylistsBy(int categoryId);
    }
}