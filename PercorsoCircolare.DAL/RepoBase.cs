using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PercorsoCircolare.DAL
{
    public abstract class RepoBase<T> : DbContext
        where T : class
    {
        private DbContext _context { get; set; }
        private DbSet<T> _dbSet { get; set; }

        protected DbContext Context => _context ?? (_context = ((EFUnitOfWork) UnitOfWork.Current).Context);

        protected DbSet<T> DbSet => _dbSet ?? (_dbSet = Context.Set<T>());

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            if (Context.Entry(entity).State == EntityState.Detached) DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            DbSet.Add(entity);
        }
    }
}