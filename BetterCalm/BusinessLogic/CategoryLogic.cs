using BusinessLogicInterface;
using Domain;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        public CategoryLogic()
        {

        }

        public List<Category> GetAll()
        {
            try
            {
                List<Category> categories = new List<Category>();
                Category category = new Category();
                categories.Add(category);
                return categories;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}