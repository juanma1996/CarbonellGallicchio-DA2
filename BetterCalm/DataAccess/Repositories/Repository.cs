using DataAccess.Context;
using DataAccessInterface;
using Domain;
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
        private readonly DbContext context;
        public Repository(DbContext context)
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
            return this.Entities.Where(predicate).FirstOrDefault();
        }

        public T Add(T domain)
        {
            this.Entities.Add(domain);
            this.context.SaveChanges();
            return domain;
        }

        public void Delete(T domain)
        {
            this.context.Remove(domain);
            this.context.SaveChanges();
        }

        public void Update(T domain)
        {
            this.context.Entry<T>(domain).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return this.Entities.Any(predicate);
        }
    }
}
