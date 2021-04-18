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

        public CategoryRepository(DbContext context)
        {
            this.context = context;
            this.categories = context.Set<Category>();
        }

        public List<Category> GetAll()
        {
            return this.categories.ToList();
        }

        public List<Playlist> GetPlaylistsBy(int categoryId)
        {
            throw new NotImplementedException();
        }

    }

}
