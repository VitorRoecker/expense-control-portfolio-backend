using ExpenseControl.Domain.Services.Interfaces.Repositories.Base;
using ExpenseControl.Domain.Services.Interfaces.Services.Base;
using System.Linq.Expressions;

namespace ExpenseControl.Domain.Services.Services.Base
{
    public class ServiceBase<TEntity, TRepository>(TRepository repository) : IServiceBase<TEntity>
                                                                                    where TEntity : class
                                                                                    where TRepository : IRepositoryBase<TEntity>
    {
        private readonly TRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<TEntity?> GetById(Guid id)
            => await _repository.GetById(id);

        public async Task<IEnumerable<TEntity>> GetAll()
            => await _repository.GetAll();
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => _repository.Find(predicate);

        public void Add(TEntity entity)
            => _repository.Add(entity);

        public void Update(TEntity entity)
            => _repository.Update(entity);

        public async void Delete(Guid id)
        {
            var entity = await _repository.GetById(id) ?? throw new Exception($"{nameof(TEntity)} Not Found");

            _repository.Remove(entity);
        }
    }
}
