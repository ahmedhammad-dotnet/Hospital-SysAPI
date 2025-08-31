using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HospitalSysAPI.Data;
using HospitalSysAPI.Repository.IRepository;

namespace HospitalSysAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext dbcontext; /*= new ApplicationDbcontext();*/
        DbSet<T> dbset;
        public Repository(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
            dbset = dbcontext.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, object>>[]? includeprop = null, Expression<Func<T, bool>>? expression = null,
            bool tracked = true)
        {
            IQueryable<T> query = dbset;

            if (includeprop != null)
            {
                foreach (var item in includeprop)
                {
                    query = query.Include(item);
                }
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return query;

        }
        public T? GetOne(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).FirstOrDefault();
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }
        public void Edit(T entity)
        {
            dbset.Update(entity);
        }
        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public void Save()
        {
            dbcontext.SaveChanges();
        }

        public T? GetOne(Expression<Func<T, object>>[]? includeprop = null, Expression<Func<T, bool>>? expression = null,
            bool tracked = true)
        {
            return GetAll(includeprop, expression, tracked).FirstOrDefault();
        }

    }
}
