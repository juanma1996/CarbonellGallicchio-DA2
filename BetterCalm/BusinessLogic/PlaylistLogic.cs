using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class PlaylistLogic : IPlaylistLogic
    {
        private readonly IRepository<Playlist> playlistRepository;

        public PlaylistLogic(IRepository<Playlist> playlistRepository)
        {
            this.playlistRepository = playlistRepository;
        }

        public List<Playlist> GetAll()
        {
            List<Playlist> playlists = playlistRepository.GetAll();
            return playlists;
        }
    }
}
