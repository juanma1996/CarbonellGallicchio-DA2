﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Domain;

namespace DataAccessInterface
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        T Add(T domain);
        void Delete(T domain);
        void Update(T domain);
        bool Exists(Expression<Func<T, bool>> predicate);
    }
}