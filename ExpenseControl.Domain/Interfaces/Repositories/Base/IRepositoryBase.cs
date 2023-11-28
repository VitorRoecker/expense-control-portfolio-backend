using System.Linq.Expressions;

namespace ExpenseControl.Domain.Services.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
