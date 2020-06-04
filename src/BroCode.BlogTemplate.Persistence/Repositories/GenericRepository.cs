using BroCode.BlogTemplate.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BroCode.BlogTemplate.Persistence.Repositories
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        protected DataContext _context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository(DataContext dataContext)
        {
            this._context = dataContext;
            this.dbSet = dataContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.AsNoTracking().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            this.dbSet.Add(entity);
            this._context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this._context.Entry(entityToUpdate).State = EntityState.Modified;

            this._context.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);
            
            dbSet.Remove(entityToDelete);
            this._context.SaveChanges();
        }
    }
}
