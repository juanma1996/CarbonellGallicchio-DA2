using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {
        List<Category> GetAll();
    }
}