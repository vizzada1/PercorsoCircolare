﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PercorsoCircolare.DAL.Interfaces;

namespace PercorsoCircolare.DAL
{
    public abstract class RepoBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DbContext _context { get; set; }
        private DbSet<TEntity> _dbSet { get; set; }

        protected DbContext Context => _context ?? (_context = ((EFUnitOfWork) UnitOfWork.Current).Context);

        protected DbSet<TEntity> DbSet => _dbSet ?? (_dbSet = Context.Set<TEntity>());

        public IQueryable<TEntity> GetQuery()
        {
            return DbSet;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where).SingleOrDefault();
        }

        public TEntity First(Expression<Func<TEntity, bool>> where)
        {
            return DbSet.Where<TEntity>(where).First();
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public int Max(Func<TEntity, int> where)
        {
            return DbSet.Max<TEntity>(where);
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        public void DeleteAll(List<TEntity> listToDelete)
        {
            foreach (TEntity ent in listToDelete)
            {
                if (Context.Entry(ent).State == System.Data.Entity.EntityState.Detached)
                {
                    DbSet.Attach(ent);
                }
                DbSet.Remove(ent);
            }
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public TEntity SingleWithNavProp(Expression<Func<TEntity, bool>> where, string propToLoad)
        {
            return DbSet.Where<TEntity>(where).Include(propToLoad).SingleOrDefault();
        }
    }
}
