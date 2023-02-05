using MongoDB.Driver;
using ProductService.Domain.Entities;
using System.Linq.Expressions;

namespace ProductService.Persistence.Interfaces
{
    public interface IMongoRepository<TEntity> where TEntity : BaseEntity
    {
        // Sync

        TEntity GetById(string id);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        IList<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity entity);
        void InsertMany(ICollection<TEntity> entities);

        TEntity Upsert(TEntity entity);
        ICollection<TEntity> UpsertMany(ICollection<TEntity> entities);

        bool UpdateById(string id, UpdateDefinition<TEntity> updateDefination);
        TEntity UpdateAndGetById(string id, UpdateDefinition<TEntity> updateDefination);
        bool UpdateWhere(Expression<Func<TEntity, bool>> predicate, UpdateDefinition<TEntity> updateDefination);

        bool DeleteById(string id);
        bool DeleteWhere(Expression<Func<TEntity, bool>> predicate);

        long CountWhere(Expression<Func<TEntity, bool>> predicate);

        // Async

        Task<TEntity> GetByIdAsync(string id);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);

        Task InsertAsync(TEntity entity);
        Task InsertManyAsync(ICollection<TEntity> entities);

        Task<TEntity> UpsertAsync(TEntity entity);
        Task<ICollection<TEntity>> UpsertManyAsync(ICollection<TEntity> entities);

        Task<bool> UpdateByIdAsync(string id, UpdateDefinition<TEntity> updateDefination);
        Task<TEntity> UpdateAndGetByIdAsync(string id, UpdateDefinition<TEntity> updateDefination);
        Task<bool> UpdateWhereAsync(Expression<Func<TEntity, bool>> predicate, UpdateDefinition<TEntity> updateDefination);

        Task<bool> DeleteByIdAsync(string id);
        Task<bool> DeleteWhereAsync(Expression<Func<TEntity, bool>> predicate);

        Task<long> CountWhereAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
