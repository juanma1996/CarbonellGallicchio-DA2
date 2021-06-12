using Adapter.Mapper;
using AdapterInterface;
using AutoMapper;
using BusinessLogicInterface;
using Model.Out;
using System.Collections.Generic;

namespace Adapter
{
    public class PlaylistLogicAdapter : IPlaylistLogicAdapter
    {
        private readonly IPlaylistLogic playlistLogic;
        private readonly IMapper mapper;

        public PlaylistLogicAdapter(IPlaylistLogic playlistLogic, IModelMapper mapper)
        {
            this.playlistLogic = playlistLogic;
            this.mapper = mapper.Configure();
        }
    public List<PlaylistBasicInfoModel> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
