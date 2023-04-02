using Microsoft.EntityFrameworkCore;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Persistence.Contexts;

namespace UserService.Persistence.Repositories
{
    public class BaseWriteRepository<TEntity> : IBaseWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ECommerceMicroserviceProjectDbContext _context;
        private readonly DbSet<TEntity> _entity;

        public BaseWriteRepository(ECommerceMicroserviceProjectDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        // Sync

        public TEntity Add(TEntity entity)
        {
            var entityState = _entity.Add(entity);
            if (entityState.State != EntityState.Added)
                return null;
            var added = _context.SaveChanges();
            return added > 0 ? entityState.Entity : null;
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            _entity.AddRange(entities);
            return _context.SaveChanges();
        }


        public TEntity Update(TEntity entity)
        {
            var entityState = _entity.Update(entity);
            if (entityState.State != EntityState.Modified)
                return null;
            var updated = _context.SaveChanges();
            return updated > 0 ? entityState.Entity : null;
        }

        public int UpdateRange(IEnumerable<TEntity> entities)
        {
            _entity.UpdateRange(entities);
            return _context.SaveChanges();
        }


        public bool Delete(Guid entityId)
        {
            var entity = _entity.Find(entityId);
            if (entity != null)
            {
                var entityState = _entity.Remove(entity);
                if (entityState.State != EntityState.Deleted)
                    return false;
                var deleted = _context.SaveChanges();
                return deleted > 0;
            }
            return false;
        }

        public bool Delete(TEntity entity)
        {
            var entityState = _entity.Remove(entity);
            if (entityState.State != EntityState.Deleted)
                return false;
            var deleted = _context.SaveChanges();
            return deleted > 0;
        }

        public int DeleteRange(IEnumerable<Guid> entities)
        {
            foreach (var entityId in entities)
            {
                var entity = _entity.Find(entityId);
                if (entity != null)
                    _entity.Remove(entity);
            }
            var deleted = _context.SaveChanges();
            return deleted;
        }

        public int DeleteRange(IEnumerable<TEntity> entities)
        {
            _entity.RemoveRange(entities);
            var deleted = _context.SaveChanges();
            return deleted;
        }

        // Async

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityState = await _entity.AddAsync(entity);
            if (entityState.State != EntityState.Added)
                return null;
            var added = await _context.SaveChangesAsync();
            return added > 0 ? entityState.Entity : null;
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entity.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityState = _entity.Update(entity);
            if (entityState.State != EntityState.Modified)
                return null;
            var updated = await _context.SaveChangesAsync();
            return updated > 0 ? entityState.Entity : null;
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _entity.UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }


        public async Task<bool> DeleteAsync(Guid entityId)
        {
            var entity = await _entity.FindAsync(entityId);
            if (entity != null)
            {
                var entityState = _entity.Remove(entity);
                if (entityState.State != EntityState.Deleted)
                    return false;
                var deleted = await _context.SaveChangesAsync();
                return deleted > 0;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            var entityState = _entity.Remove(entity);
            if (entityState.State != EntityState.Deleted)
                return false;
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<Guid> entities)
        {
            foreach (var entityId in entities)
            {
                var entity = await _entity.FindAsync(entityId);
                if (entity != null)
                    _entity.Remove(entity);
            }
            var deleted = await _context.SaveChangesAsync();
            return deleted;
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _entity.Remove(entity);
            }
            var deleted = await _context.SaveChangesAsync();
            return deleted;
        }

        // Helpers

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
