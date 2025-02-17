using AuthKit.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Infrastructure.Repositories
{
    public class EfRepository<TDbContext, TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
                                                                                  where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        protected bool AutoFlushEnabled { get; set; }
        protected TDbContext DbContext { get { return _dbContext; } }
        protected DbSet<TEntity> DbSet { get { return _dbSet; } }

        public EfRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public EfRepository(TDbContext dbContext, bool autoFlushEnabled) : this(dbContext)
        {
            AutoFlushEnabled = autoFlushEnabled;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Add(entity);

            if (AutoFlushEnabled)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (AutoFlushEnabled)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;

            if (AutoFlushEnabled)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(expression).ToListAsync(cancellationToken: cancellationToken); ;
        }

        public virtual async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(expression, cancellationToken: cancellationToken);
        }

        public void BulkUpdate(List<TEntity> entitiesToUpdate)
        {
            foreach (var entity in entitiesToUpdate)
            {
                _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public async Task BulkInsert(List<TEntity> entitiesToInsert)
        {
            _dbContext.Set<TEntity>().AddRange(entitiesToInsert);
            await _dbContext.SaveChangesAsync();
        }
    }
}
