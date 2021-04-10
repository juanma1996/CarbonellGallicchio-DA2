using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DataAccessInterface
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        List<Playlist> GetPlaylistsBy(int categoryId);
    }
}
