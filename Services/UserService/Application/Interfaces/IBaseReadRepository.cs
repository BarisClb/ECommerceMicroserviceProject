using System.Linq.Expressions;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IBaseReadRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        // Sync

        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid entityId);
        TEntity GetById(Guid entityId, IEnumerable<string> includes);

        TEntity GetFirstWhere(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirstWhere(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes);

        IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes);

        IEnumerable<TEntity> GetList(int pageNumber, int pageSize);
        IEnumerable<TEntity> GetList(int pageNumber, int pageSize, IEnumerable<string> includes);
        IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes);
        IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
        IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes);
        IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes);

        // Sync (TResult)

        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> returnObject);
        TResult GetById<TResult>(Guid entityId, Expression<Func<TEntity, TResult>> returnObject);
        TResult GetById<TResult>(Guid entityId, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject);

        TResult GetFirstWhere<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject);
        TResult GetFirstWhere<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject);

        IEnumerable<TResult> GetWhere<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetWhere<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject);

        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject);
        IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject);

        // Async

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(Guid entityId, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(Guid entityId, IEnumerable<string> includes, CancellationToken cancellationToken = default);

        Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, IEnumerable<string> includes, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default);

        // Async (TResult)

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<TResult> GetByIdAsync<TResult>(Guid entityId, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<TResult> GetByIdAsync<TResult>(Guid entityId, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);

        Task<TResult> GetFirstWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<TResult> GetFirstWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);

        Task<IEnumerable<TResult>> GetWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);

        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default);

        // Helpers

        int Count(Expression<Func<TEntity, bool>>? predicate = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);

        // Specials

        Task<IEnumerable<TEntity>> GetAsync(int? pageNumber = default, int? pageSize = default, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = default, Expression<Func<TEntity, bool>>? predicate = default, IEnumerable<string>? includes = default, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> returnObject, int? pageNumber = default, int? pageSize = default, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = default, Expression<Func<TEntity, bool>>? predicate = default, IEnumerable<string>? includes = default, CancellationToken cancellationToken = default);
    }
}
