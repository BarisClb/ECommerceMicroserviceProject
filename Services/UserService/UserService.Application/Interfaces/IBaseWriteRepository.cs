using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IBaseWriteRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        // Sync

        TEntity Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);
        int UpdateRange(IEnumerable<TEntity> entities);

        bool Delete(Guid entityId);
        bool Delete(TEntity entity);
        int DeleteRange(IEnumerable<Guid> entities);
        int DeleteRange(IEnumerable<TEntity> entities);

        // Async

        Task<TEntity> AddAsync(TEntity entity);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> DeleteAsync(Guid entityId);
        Task<bool> DeleteAsync(TEntity entity);
        Task<int> DeleteRangeAsync(IEnumerable<Guid> entities);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities);

        // Helpers

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
