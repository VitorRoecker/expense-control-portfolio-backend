using System.Linq.Expressions;

namespace ExpenseControl.Domain.Services.Interfaces.Services.Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}
