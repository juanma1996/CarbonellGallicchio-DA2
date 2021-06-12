using BusinessExceptions;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidatorInterface;

namespace BusinessLogic
{
    public class PlayableContentLogic : IPlayableContentLogic
    {
        private IRepository<PlayableContent> playableContentRepository;
        private IValidator<AudioContent> audioContentValidator;
        private IRepository<CategoryPlaylist> categoryPlaylistRepository;
        private IRepository<Category> categoryRepository;
        private IRepository<Playlist> playlistRepository;
        private IRepository<PlayableContentPlaylist> playableContentPlaylistRepository;

        public PlayableContentLogic(IRepository<PlayableContent> playableContentRepository,
            IValidator<AudioContent> audioContentValidator, IRepository<CategoryPlaylist> categoryPlaylistRepository,
            IRepository<Category> categoryRepository, IRepository<Playlist> playlistRepository, IRepository<PlayableContentPlaylist> playableContentPlaylistRepository)
        {
            this.playableContentRepository = playableContentRepository;
            this.audioContentValidator = audioContentValidator;
            this.categoryPlaylistRepository = categoryPlaylistRepository;
            this.categoryRepository = categoryRepository;
            this.playlistRepository = playlistRepository;
            this.playableContentPlaylistRepository = playableContentPlaylistRepository;
        }

        public PlayableContent GetById(int playableContentId)
        {
            PlayableContent playableContent = playableContentRepository.GetById(playableContentId);
            if (playableContent is AudioContent audioContent)
            {
                audioContentValidator.Validate(audioContent);
            }
            else if (playableContent is null)
            {
                audioContentValidator.Validate(null);
            }
            playableContent.Categories = GetCategoriesByPlayableContent(playableContent);
            playableContent.Playlists = GetPlaylistsByPlayableContent(playableContent);

            return playableContent;

        }

        private List<PlayableContentCategory> GetCategoriesByPlayableContent(PlayableContent playableContent)
        {
            var categories = categoryRepository.GetAll(category => category.PlayableContents.Any(a => a.PlayableContentId == playableContent.Id));
            List<PlayableContentCategory> playableContentCategories = new List<PlayableContentCategory>();
            categories.ForEach(c => playableContentCategories.Add(GetPlayableContentCategory(c, playableContent)));

            return playableContentCategories;
        }

        private PlayableContentCategory GetPlayableContentCategory(Category category, PlayableContent playableContent)
        {
            PlayableContentCategory playableContentCategory = new PlayableContentCategory()
            {
                Category = category,
                PlayableContent = playableContent
            };

            return playableContentCategory;
        }

        private List<PlayableContentPlaylist> GetPlaylistsByPlayableContent(PlayableContent playableContent)
        {
            var playlists = playlistRepository.GetAll(playlist => playlist.PlayableContents.Any(a => a.PlayableContentId == playableContent.Id));
            List<PlayableContentPlaylist> playableContentPlaylists = new List<PlayableContentPlaylist>();
            playlists.ForEach(p => playableContentPlaylists.Add(GetPlayableContentPlaylist(p, playableContent)));

            return playableContentPlaylists;
        }

        private PlayableContentPlaylist GetPlayableContentPlaylist(Playlist playlist, PlayableContent playableContent)
        {
            PlayableContentPlaylist playableContentPlaylist = new PlayableContentPlaylist()
            {
                Playlist = playlist,
                PlayableContent = playableContent
            };

            return playableContentPlaylist;
        }

        public PlayableContent Create(PlayableContent playableContent)
        {
            ValidateExistPlaylistAndCategoryByPlayableContent(playableContent);
            playableContentRepository.Add(playableContent);
            CreateCategoryPlaylist(playableContent.Playlists, playableContent.Categories);

            return playableContent;
        }

        private void CreateCategoryPlaylist(List<PlayableContentPlaylist> playableContentPlaylists, List<PlayableContentCategory> playableContentCategories)
        {
            foreach (PlayableContentPlaylist playableContentPlaylist in playableContentPlaylists)
            {
                foreach (PlayableContentCategory playableContentCategory in playableContentCategories)
                {
                    if (!categoryPlaylistRepository.Exists(p => p.CategoryId == playableContentCategory.CategoryId
                    && p.PlaylistId == playableContentPlaylist.PlaylistId))
                    {

                        CategoryPlaylist categoryPlaylist = new CategoryPlaylist()
                        {
                            CategoryId = playableContentCategory.CategoryId,
                            PlaylistId = playableContentPlaylist.PlaylistId
                        };
                        categoryPlaylistRepository.Add(categoryPlaylist);
                    }
                }
            }
        }

        private void ValidateExistPlaylistAndCategoryByPlayableContent(PlayableContent playableContent)
        {
            ValidateExistCategoryByPlayableContent(playableContent);
            ValidateExistPlaylistByPlayableContent(playableContent);
        }

        private void ValidateExistPlaylistByPlayableContent(PlayableContent playableContent)
        {
            bool existPlaylist = true;
            playableContent.Playlists.ForEach(p =>
            existPlaylist = existPlaylist && (p.PlaylistId == default || playlistRepository.Exists(pl => pl.Id == p.PlaylistId)));
            if (!existPlaylist)
            {
                throw new NullObjectException("Playlist not exist for the given data");
            }
        }

        private void ValidateExistCategoryByPlayableContent(PlayableContent playableContent)
        {
            bool existCategory = true;
            playableContent.Categories.ForEach(c =>
            existCategory = existCategory && categoryRepository.Exists(ca => ca.Id == c.CategoryId));
            if (!existCategory)
            {
                throw new NullObjectException("Category not exist for the given data");
            }
        }

        public void DeleteById(int playableContentId)
        {
            PlayableContent playableContentToDelete = GetById(playableContentId);
            playableContentRepository.Delete(playableContentToDelete);
        }
        public void Update(PlayableContent playableContent)
        {
            if (!playableContentRepository.Exists(a => a.Id == playableContent.Id))
            {
                throw new NullObjectException("Audio content not exist for the given data");
            }
            else
            {
                ValidateExistPlaylistAndCategoryByPlayableContent(playableContent);
                CreatePlaylists(playableContent);
                playableContentRepository.Update(playableContent);
                CreatePlayableContentPlaylist(playableContent.Playlists);
                CreateCategoryPlaylist(playableContent.Playlists, playableContent.Categories);
            }
        }

        private void CreatePlaylists(PlayableContent playableContent)
        {
            foreach (var item in playableContent.Playlists)
            {
                if (item.Playlist != null && item.Playlist.Id == default)
                {
                    item.Playlist = playlistRepository.Add(item.Playlist);
                    item.PlaylistId = item.Playlist.Id;
                    item.PlayableContent = playableContent;
                    item.PlayableContentId = playableContent.Id;
                }
            }
        }

        private void CreatePlayableContentPlaylist(List<PlayableContentPlaylist> playlists)
        {
            foreach (PlayableContentPlaylist item in playlists)
            {
                playableContentPlaylistRepository.Add(item);
            }
        }

        public List<PlayableContent> GetByCategoryId(int categoryId)
        {
            List<PlayableContent> playableContents = playableContentRepository.GetAll(p => p.Categories.Any(pCategory => pCategory.CategoryId == categoryId));
            return playableContents;
        }

        public List<PlayableContent> GetByPlaylistId(int playlistId)
        {
            List<PlayableContent> playableContents = playableContentRepository.GetAll(p => p.Playlists.Any(pPlaylist => pPlaylist.PlaylistId == playlistId));
            return playableContents;
        }

        public List<PlayableContent> GetAll()
        {
            List<PlayableContent> playableContents = playableContentRepository.GetAll();
            return playableContents;
        }
    }
}