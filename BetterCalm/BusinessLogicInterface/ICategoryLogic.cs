using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {
        List<Category> GetAll();
        List<Playlist> GetPlaylistsByCategoryId(int categoryId);
    }
}