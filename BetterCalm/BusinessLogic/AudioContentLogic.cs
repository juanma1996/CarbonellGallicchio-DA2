using BusinessExceptions;
using BusinessLogicInterface;
using DataAccessInterface;
using Domain;
using System.Collections.Generic;
using ValidatorInterface;

namespace BusinessLogic
{
    public class AudioContentLogic : IAudioContentLogic
    {
        private IRepository<AudioContent> audioContentRepository;
        private IValidator<AudioContent> audioContentValidator;
        private IRepository<CategoryPlaylist> categoryPlaylistRepository;
        private IRepository<Category> categoryRepository;
        private IRepository<Playlist> playlistRepository;

        public AudioContentLogic(IRepository<AudioContent> audioContentRepository,
            IValidator<AudioContent> audioContentValidator, IRepository<CategoryPlaylist> categoryPlaylistRepository,
            IRepository<Category> categoryRepository, IRepository<Playlist> playlistRepository)
        {
            this.audioContentRepository = audioContentRepository;
            this.audioContentValidator = audioContentValidator;
            this.categoryPlaylistRepository = categoryPlaylistRepository;
            this.categoryRepository = categoryRepository;
            this.playlistRepository = playlistRepository;
        }
        public AudioContent GetById(int audioContentId)
        {
            AudioContent audioContent = audioContentRepository.GetById(audioContentId);
            audioContentValidator.Validate(audioContent);
            return audioContent;

        }
        public AudioContent Create(AudioContent audioContent)
        {
            bool existCategory = true;
            bool existPlaylist = true;
            audioContent.Categories.ForEach(c =>
            existCategory = existCategory && categoryRepository.Exists(ca => ca.Id == c.CategoryId));
            audioContent.Playlists.ForEach(p =>
            existPlaylist = existPlaylist && (p.PlaylistId == default ||  playlistRepository.Exists(pl => pl.Id == p.PlaylistId)));
            if (!existCategory)
            {
                throw new NullObjectException("Category not exist for the given data");
            }
            if (!existPlaylist)
            {
                throw new NullObjectException("Playlist not exist for the given data");
            }
            else
            {
                AudioContent audioContentAdded = audioContentRepository.Add(audioContent);
                CreateCategoryPlaylist(audioContent.Playlists, audioContent.Categories);
            }

            return audioContent;
        }

        private void CreateCategoryPlaylist(List<AudioContentPlaylist> audioContentPlaylists, List<AudioContentCategory> audioContentCategories)
        {
            foreach (AudioContentPlaylist audioContentPlaylist in audioContentPlaylists)
            {
                foreach (AudioContentCategory audioContentCategory in audioContentCategories)
                {
                    if (!categoryPlaylistRepository.Exists(p => p.CategoryId == audioContentCategory.CategoryId
                    && p.PlaylistId == audioContentPlaylist.PlaylistId))
                    {

                        CategoryPlaylist categoryPlaylist = new CategoryPlaylist()
                        {
                            CategoryId = audioContentCategory.CategoryId,
                            PlaylistId = audioContentPlaylist.PlaylistId
                        };
                        categoryPlaylistRepository.Add(categoryPlaylist); 
                    }
                }
            }
        }

        public void DeleteById(int audioContentId)
        {
            AudioContent audioContentToDelete = GetById(audioContentId);
            audioContentRepository.Delete(audioContentToDelete);
        }
        public void Update(AudioContent audioContent)
        {
            if (!audioContentRepository.Exists(a => a.Id == audioContent.Id))
            {
                throw new NullObjectException("Audio content not exist for the given data");
            }
            else
            {
                audioContentRepository.Update(audioContent);
                CreateCategoryPlaylist(audioContent.Playlists, audioContent.Categories);
            }
        }
    }
}