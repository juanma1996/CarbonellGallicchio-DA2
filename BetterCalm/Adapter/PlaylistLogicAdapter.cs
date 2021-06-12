using Adapter.Mapper;
using AdapterInterface;
using AutoMapper;
using BusinessLogicInterface;
using Domain;
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
            List<Playlist> playlists = playlistLogic.GetAll();
            List<PlaylistBasicInfoModel> playlistsBasicInfoModel = mapper.Map<List<PlaylistBasicInfoModel>>(playlists);
            return playlistsBasicInfoModel;
        }
    }
}
