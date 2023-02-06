using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace e07.domain.repository;

public class Repository<T> : IRepository<T> where T : class, new()
{

    protected readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }
    public void Add(T entity) => _context.Set<T>().Add(entity);

    public void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);

    public async Task<T> Find(Expression<Func<T, bool>> predicate) => await _context.Set<T>().FirstOrDefaultAsync(predicate);


    public async Task<T> Get(string id) => await _context.FindAsync<T>(id);

    public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

    public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

    public void Remove(T entity) => _context.Set<T>().Remove(entity);

    public void RemoveRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void UpdateRange(IEnumerable<T> entities) => _context.Set<T>().UpdateRange(entities);
}