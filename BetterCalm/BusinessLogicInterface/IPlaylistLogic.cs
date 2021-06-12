using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IPlaylistLogic
    {
        List<Playlist> GetAll();
    }
}
