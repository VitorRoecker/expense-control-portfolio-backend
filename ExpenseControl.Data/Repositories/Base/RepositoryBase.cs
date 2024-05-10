using ExpenseControl.Domain.Services.Interfaces.Repositories.Base;
using ExpenseControl.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExpenseControl.Data.Repositories.Base
{
    public class RepositoryBase<TEntity>(DatabaseContext context) : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext Context = context ?? throw new ArgumentNullException(nameof(context));
        protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

        public virtual async Task<TEntity?> GetById(Guid id)
            => await DbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAll()
            => await DbSet.AsNoTracking().ToListAsync();

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => DbSet.AsNoTracking().Where(predicate);

        public virtual async void Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            Context.SaveChanges();
        }

        public virtual async void AddRange(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            Context.SaveChanges();
        }

        public virtual async void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            Context.SaveChanges();
        }
    }
}
