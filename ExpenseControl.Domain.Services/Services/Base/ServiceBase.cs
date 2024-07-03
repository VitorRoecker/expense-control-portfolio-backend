using ExpenseControl.Domain.Services.Interfaces.Repositories.Base;
using ExpenseControl.Domain.Services.Interfaces.Services.Base;

namespace ExpenseControl.Domain.Services.Services.Base
{
    public class ServiceBase<TEntity, TRepository>(TRepository repository) : IServiceBase<TEntity>
                                                                                    where TEntity : class
                                                                                    where TRepository : IRepositoryBase<TEntity>
    {
        private readonly TRepository _repository = repository;

        public TEntity Add(TEntity entity)
            => _repository.Add(entity);

        public void Delete(TEntity entity)
            => _repository.Delete(entity);

        public IEnumerable<TEntity> GetAll()
            => _repository.GetAll();

        public TEntity GetById(Guid id)
            => _repository.GetById(id);

        public void Update(TEntity entity)
            => _repository.Update(entity);
    }
}
