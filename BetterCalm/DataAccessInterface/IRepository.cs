using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
    }
}
