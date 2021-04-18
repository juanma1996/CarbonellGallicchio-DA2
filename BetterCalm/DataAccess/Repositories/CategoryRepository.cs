using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContext context;
        private readonly DbSet<Category> categories;
        private readonly DbSet<Playlist> playlists;

        public CategoryRepository(DbContext context)
        {
            this.context = context;
            this.categories = context.Set<Category>();
            this.playlists = context.Set<Playlist>();
        }

        public List<Category> GetAll()
        {
            return this.categories.ToList();
        }

        public List<Playlist> GetPlaylistsBy(int categoryId)
        {
            return this.categories.Where(c => c.Id.Equals(categoryId)).FirstOrDefault().Playlists;
        }

    }

}
