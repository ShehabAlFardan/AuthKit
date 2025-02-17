using System.Linq.Expressions;

namespace AuthKit.Domain.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllByExpressionAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);
        void BulkUpdate(List<TEntity> entitiesToUpdate);
        Task BulkInsert(List<TEntity> entitiesToInsert);
    }
}
