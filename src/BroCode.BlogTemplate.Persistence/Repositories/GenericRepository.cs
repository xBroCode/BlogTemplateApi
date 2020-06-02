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


        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return this.dbSet.Find(id);
        }
    }
}
