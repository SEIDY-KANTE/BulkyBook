using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    //HERE MY GENERIC REPOSITORY
    //Of course, as the requirement changes, we will be making modifications here
    //and when we make modification in the repository, all the classes that implements
   //this repository will get the update as well so that.

   //So that way, we don't have to go to all the places to update the change
    public class Repository<T> : IRepository<T> where T : class
    {
        //From our DbContext, we can get DbSet instance and work on that directly
        internal DbSet<T> dbSet;
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet=_db.Set<T>(); //That is calling our repository
        }

        public void Add(T entity)
        {
           dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            //We will return an inumerable of T like we might want to query our data before we return
            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
