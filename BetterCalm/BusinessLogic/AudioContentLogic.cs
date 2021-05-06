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

        public AudioContentLogic(IRepository<AudioContent> audioContentRepository,
            IValidator<AudioContent> audioContentValidator, IRepository<CategoryPlaylist> categoryPlaylistRepository)
        {
            this.audioContentRepository = audioContentRepository;
            this.audioContentValidator = audioContentValidator;
            this.categoryPlaylistRepository = categoryPlaylistRepository;
        }
        public AudioContent GetById(int audioContentId)
        {
            AudioContent audioContent = audioContentRepository.GetById(audioContentId);
            audioContentValidator.Validate(audioContent);
            return audioContent;

        }
        public AudioContent Create(AudioContent audioContent)
        {
            AudioContent audioContentAdded = audioContentRepository.Add(audioContent);
            CreateCategoryPlaylist(audioContent.Playlists, audioContent.Categories);

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