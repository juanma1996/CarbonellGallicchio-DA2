using BusinessLogicInterface;
using Domain;
using System;
using System.Collections.Generic;
using DataAccessInterface;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = categoryRepository.GetAll();
            return categories;
        }
    }
}