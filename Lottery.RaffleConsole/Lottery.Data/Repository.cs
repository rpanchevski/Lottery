﻿using System.Linq;
using Lottery.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Lottery.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected DbSet<T> DbSet;
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            DbSet = dbContext.Set<T>();
            _dbContext = dbContext;
        }
        public void Insert(T entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
