using System.Linq.Expressions;

namespace HospitalSysAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, object>>[]? includeprop = null, Expression<Func<T, bool>>? expression = null,
    bool tracked = true);
        T? GetOne(Expression<Func<T, object>>[]? includeprop = null, Expression<Func<T, bool>>? expression = null, bool tracked = true);
        void Add(T category);

        void Edit(T category);

        void Delete(T category);

        void Save();
    }
}
