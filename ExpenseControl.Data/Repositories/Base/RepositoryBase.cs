using ExpenseControl.Domain.Entities.Base;
using ExpenseControl.Domain.Services.Interfaces.Repositories.Base;
using ExpenseControl.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Data.Repositories.Base
{
    public class RepositoryBase<TEntity>(DatabaseContext context) : IRepositoryBase<TEntity> 
        where TEntity : class
    {
        private readonly DatabaseContext _context = context;
        private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public IEnumerable<TEntity> GetAll()
            => [.. _dbSet];

        public TEntity GetById(Guid id)
            => _dbSet.Find(id);

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
