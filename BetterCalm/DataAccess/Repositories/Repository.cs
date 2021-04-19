using DataAccess.Context;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<T> GetAll()
        {
            return this.Entities.ToList();
        }
        public T GetById(int id)
        {
            return this.Entities.Find(id);
        }
    }
}
