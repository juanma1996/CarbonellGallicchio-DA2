using Model.Out;
using System.Collections.Generic;

namespace AdapterInterface
{
    public interface IPlaylistLogicAdapter
    {
        List<PlaylistBasicInfoModel> GetAll();
    }
}
