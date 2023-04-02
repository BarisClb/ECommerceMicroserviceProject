using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Persistence.Contexts;

namespace UserService.Persistence.Repositories
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ECommerceMicroserviceProjectDbContext _context;
        private readonly DbSet<TEntity> _entity;

        public BaseReadRepository(ECommerceMicroserviceProjectDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        // Sync

        public IEnumerable<TEntity> GetAll()
        {
            return _entity.ToList();
        }

        public TEntity GetById(Guid entityId)
        {
            return _entity.Find(entityId);
        }

        public TEntity GetById(Guid entityId, IEnumerable<string> includes)
        {
            IQueryable<TEntity> query = _entity.Where(entity => entity.Id == entityId);

            foreach (var include in includes)
                query = query.Include(include);

            return query.FirstOrDefault();
        }

        public TEntity GetFirstWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.FirstOrDefault(predicate);
        }

        public TEntity GetFirstWhere(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return query.ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize)
        {
            return _entity.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize, IEnumerable<string> includes)
        {
            IQueryable<TEntity> query = _entity;

            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            return _entity.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetList(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        // Sync (TResult)

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> returnObject)
        {
            return _entity.Select(returnObject).ToList();
        }

        public TResult GetById<TResult>(Guid entityId, Expression<Func<TEntity, TResult>> returnObject)
        {
            return _entity.Where(entity => entity.Id == entityId).Select(returnObject).FirstOrDefault();
        }

        public TResult GetById<TResult>(Guid entityId, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity.Where(entity => entity.Id == entityId);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Select(returnObject).FirstOrDefault();
        }

        public TResult GetFirstWhere<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject)
        {
            return _entity.Where(predicate).Select(returnObject).FirstOrDefault();
        }

        public TResult GetFirstWhere<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Select(returnObject).FirstOrDefault();
        }

        public IEnumerable<TResult> GetWhere<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject)
        {
            return _entity.Where(predicate).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetWhere<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, TResult>> returnObject)
        {
            return _entity.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity;

            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject)
        {
            return _entity.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToList();
        }

        // Async

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entity.ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(Guid entityId, CancellationToken cancellationToken = default)
        {
            return await _entity.FindAsync(entityId, cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(Guid entityId, IEnumerable<string> includes, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(entity => entity.Id == entityId);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _entity.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _entity.Where(predicate).ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            return await _entity.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, IEnumerable<string> includes, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _entity.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        }

        // Async (TResult)

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            return await _entity.Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<TResult> GetByIdAsync<TResult>(Guid entityId, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            return await _entity.Where(entity => entity.Id == entityId).Select(returnObject).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult> GetByIdAsync<TResult>(Guid entityId, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(entity => entity.Id == entityId);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Select(returnObject).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult> GetFirstWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            return await _entity.Where(predicate).Select(returnObject).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult> GetFirstWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Select(returnObject).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            return await _entity.Where(predicate).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetWhereAsync<TResult>(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            return await _entity.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            return await _entity.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, bool>> predicate, IEnumerable<string> includes, Expression<Func<TEntity, TResult>> returnObject, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity.Where(predicate);

            query = orderBy(query);

            foreach (var include in includes)
                query = query.Include(include);

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(returnObject).ToListAsync(cancellationToken);
        }

        // Helpers


        public int Count(Expression<Func<TEntity, bool>>? predicate = null)
        {
            if (predicate == null)
                return _entity.Count();
            else
                return _entity.Count(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            if (predicate == null)
                return await _entity.CountAsync(cancellationToken);
            else
                return await _entity.CountAsync(predicate, cancellationToken);
        }

        // Specials

        public async Task<IEnumerable<TEntity>> GetAsync(int? pageNumber = default, int? pageSize = default, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = default, Expression<Func<TEntity, bool>>? predicate = default, IEnumerable<string>? includes = default, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = orderBy(query);
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            if (pageSize != null)
                query = query.Skip(((pageNumber ?? 1) - 1) * (pageSize ?? 1)).Take(pageSize ?? 1);

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> returnObject, int? pageNumber = default, int? pageSize = default, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = default, Expression<Func<TEntity, bool>>? predicate = default, IEnumerable<string>? includes = default, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = orderBy(query);
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            if (pageSize != null)
                query = query.Skip(((pageNumber ?? 1) - 1) * (pageSize ?? 1)).Take(pageSize ?? 1);

            return await query.Select(returnObject).ToListAsync(cancellationToken);
        }
    }
}
