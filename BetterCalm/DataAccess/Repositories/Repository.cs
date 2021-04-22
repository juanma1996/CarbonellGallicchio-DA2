using DataAccess.Context;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BetterCalmContext context;
        public Repository(BetterCalmContext context)
        {
            this.context = context;
        }
        protected DbSet<T> Entities
        {
            get
            {
                return this.context.Set<T>();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null ? this.Entities.Where(predicate).ToList() : this.Entities.ToList();
        }
        public T GetById(int id)
        {
            return this.Entities.Find(id);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Where(predicate).First();
        }

        public T Add(T domain)
        {
            throw new NotImplementedException();
        }

        public void Delete(T domain)
        {
            throw new NotImplementedException();
        }

        public void Update(T domain)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
