using AdapterInterface;
using Model.Out;
using System.Collections.Generic;

namespace Adapter
{
    public class PlaylistLogicAdapter : IPlaylistLogicAdapter
    {
        public List<PlaylistBasicInfoModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
