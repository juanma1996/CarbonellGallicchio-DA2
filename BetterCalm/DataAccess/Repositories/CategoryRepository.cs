﻿using DataAccessInterface;
using Domain;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Playlist> GetPlaylistsBy(int categoryId)
        {
            throw new NotImplementedException();
        }

    }

}