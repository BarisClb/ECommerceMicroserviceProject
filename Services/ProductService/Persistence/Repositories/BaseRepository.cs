using MongoDB.Driver;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using System.Linq.Expressions;

namespace ProductService.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;

        public BaseRepository(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        // Sync

        public virtual TEntity GetById(string id)
        {
            return _collection.Find(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public virtual TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).FirstOrDefault();
        }

        public virtual IList<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public virtual void InsertMany(ICollection<TEntity> entities)
        {
            _collection.InsertMany(entities);
        }

        public virtual TEntity Upsert(TEntity entity)
        {
            var result = _collection.ReplaceOne(e => e.Id.Equals(entity.Id), entity, new UpdateOptions { IsUpsert = true }).IsAcknowledged;
            return result ? entity : null;
        }

        public virtual ICollection<TEntity> UpsertMany(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Upsert(entity);
            }
            return entities;
        }

        public virtual bool UpdateById(string id, UpdateDefinition<TEntity> updateDefination)
        {
            return _collection.UpdateOne(x => x.Id.Equals(id), updateDefination).IsAcknowledged;
        }

        public virtual TEntity UpdateAndGetById(string id, UpdateDefinition<TEntity> updateDefination)
        {
            return _collection.FindOneAndUpdate<TEntity>(x => x.Id.Equals(id), updateDefination, new FindOneAndUpdateOptions<TEntity> { ReturnDocument = ReturnDocument.After });
        }

        public virtual bool UpdateWhere(Expression<Func<TEntity, bool>> predicate, UpdateDefinition<TEntity> updateDefination)
        {
            var updateResult = _collection.UpdateMany<TEntity>(predicate, updateDefination);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public virtual bool DeleteById(string id)
        {
            return _collection.DeleteOne(x => x.Id.Equals(id)).IsAcknowledged;
        }

        public virtual bool DeleteWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.DeleteOne(predicate).IsAcknowledged;
        }

        // Async

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            return await (await _collection.FindAsync(x => x.Id.Equals(id))).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await (await _collection.FindAsync(predicate)).FirstOrDefaultAsync();
        }

        public virtual async Task<IList<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await _collection.FindAsync(predicate)).ToList();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task InsertManyAsync(ICollection<TEntity> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public virtual async Task<TEntity> UpsertAsync(TEntity entity)
        {
            var result = (await _collection.ReplaceOneAsync(e => e.Id.Equals(entity.Id), entity, new UpdateOptions { IsUpsert = true })).IsAcknowledged;
            return result ? entity : null;
        }

        public virtual async Task<ICollection<TEntity>> UpsertManyAsync(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await UpsertAsync(entity);
            }
            return entities;
        }

        public virtual async Task<bool> UpdateByIdAsync(string id, UpdateDefinition<TEntity> updateDefination)
        {
            return (await _collection.UpdateOneAsync(x => x.Id.Equals(id), updateDefination)).IsAcknowledged;
        }

        public virtual async Task<TEntity> UpdateAndGetByIdAsync(string id, UpdateDefinition<TEntity> updateDefination)
        {
            return await _collection.FindOneAndUpdateAsync<TEntity>(x => x.Id.Equals(id), updateDefination, new FindOneAndUpdateOptions<TEntity> { ReturnDocument = ReturnDocument.After });
        }

        public virtual async Task<bool> UpdateWhereAsync(Expression<Func<TEntity, bool>> predicate, UpdateDefinition<TEntity> updateDefination)
        {
            var updateResult = await _collection.UpdateManyAsync<TEntity>(predicate, updateDefination);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public virtual async Task<bool> DeleteByIdAsync(string id)
        {
            return (await _collection.DeleteOneAsync(x => x.Id.Equals(id))).IsAcknowledged;
        }

        public virtual async Task<bool> DeleteWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return (await _collection.DeleteManyAsync(predicate)).IsAcknowledged;
        }

        // Helpers

        public virtual long CountWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.CountDocuments<TEntity>(predicate);
        }

        public virtual async Task<long> CountWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.CountDocumentsAsync<TEntity>(predicate);
        }
    }
}
